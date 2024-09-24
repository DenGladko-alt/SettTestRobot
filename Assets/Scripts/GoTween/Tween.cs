using System;
using UnityEngine;

namespace GoTween
{
    public class Tween
    {
        private Action<float> OnUpdate;
        private Action OnCompleteCallback;
        
        private float _elapsedTime = 0f;

        private EaseType _easeType = EaseType.Linear;
        private bool _isComplete = false;
        
        private bool _isPaused = false;
        
        public object StartValue { get; private set; }
        
        public float Duration { get; private set; } = 0f;
        
        public float StartingSequenceDelay { get; set; }
        public float EndingSequenceDelay { get; set; }

        public Tween(Action<float> onUpdate, float duration, bool isPaused = false)
        {
            OnUpdate = onUpdate ?? throw new ArgumentNullException(nameof(onUpdate));
            Duration = duration;
            _isPaused = isPaused;
            
            if (TweenManager.Instance == null)
            {
                throw new InvalidOperationException("TweenManager.Instance is null. Tween cannot be added.");
            }
            
            TweenManager.Instance.AddTween(this);
        }

        public bool UpdateTween(float deltaTime)
        {
            if (_isComplete) return true;            
            
            if (_isPaused) return false;

            _elapsedTime += deltaTime;
            
            if (Duration <= 0 || _elapsedTime >= Duration)
            {
                _elapsedTime = Duration;
                OnUpdate?.Invoke(1f);
                _isComplete = true;
                OnCompleteCallback?.Invoke();
                return true;
            }
            
            float progress = Mathf.Clamp01(_elapsedTime / Duration);
            progress = Easing.GetEase(_easeType, progress);
            OnUpdate?.Invoke(progress);
            return false;
        }

        public Tween AddOnCompleteCallback(Action callback)
        {
            OnCompleteCallback += callback;
            return this;
        }

        public Tween SetEase(EaseType easeType)
        {
            _easeType = easeType;
            return this;
        }

        public Tween Resume()
        {
            _isPaused = false;
            return this;
        }

        public Tween Pause()
        {
            _isPaused = true;
            return this;
        }

        public Tween Reset()
        {
            Duration = 0f;
            _elapsedTime = 0f;
            _easeType = EaseType.Linear;
            _isComplete = false;
            _isPaused = false;

            StartingSequenceDelay = 0f;
            EndingSequenceDelay = 0f;
            
            OnUpdate = null;
            OnCompleteCallback = null;

            return this;
        }

        public Tween UpdateStartingValue()
        {
            
            return this;
        }
    }
}