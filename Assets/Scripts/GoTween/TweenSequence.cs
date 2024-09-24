using System;
using System.Collections.Generic;
using UnityEngine;

namespace GoTween
{
    public class TweenSequence
    {
        public event Action OnCompleteCallback;
        
        private List<Tween> _tweens = new List<Tween>();
        
        private float _elapsedTime = 0;
        
        private bool _isPlaying = false;
        private float _lastTweenDelay = 0;

        public TweenSequence()
        {
            if (TweenManager.Instance == null)
            {
                throw new InvalidOperationException("TweenManager.Instance is null. Sequence cannot be added.");
            }
            
            TweenManager.Instance.AddSequence(this);
        }

        public TweenSequence Append(Tween tween)
        {
            if (tween == null) return this;
            
            if (TweenManager.Instance == null)
            {
                throw new InvalidOperationException("TweenManager.Instance is null.");
            }
            
            _tweens.Add(tween);
            TweenManager.Instance.RemoveTween(tween);
            
            tween.StartingSequenceDelay = _lastTweenDelay;
            _lastTweenDelay += tween.Duration;
            tween.EndingSequenceDelay = _lastTweenDelay;
            
            return this;
        }

        public TweenSequence Play()
        {
            if (_isPlaying) return this;

            if (_tweens.Count == 0)
            {
                Debug.LogWarning("Attempting to play a sequence without any tweens");
            }

            _isPlaying = true;
            return this;
        }

        public TweenSequence Pause()
        {
            _isPlaying = false;
            return this;
        }

        public bool UpdateSequence(float deltaTime)
        {
            if (!_isPlaying) return false;
            
            _elapsedTime += deltaTime;
            if (_tweens.Count > 0)
            {
                for (int i = _tweens.Count - 1; i >= 0; i--)
                {
                    if (_tweens[i].StartingSequenceDelay <= _elapsedTime)
                    {
                        TweenManager.Instance.AddTween(_tweens[i]);
                        _tweens.Remove(_tweens[i]);
                    }
                }
            }
    
            if (_elapsedTime > _lastTweenDelay)
            {
                _isPlaying = false;
                OnCompleteCallback?.Invoke();
                return true;
            }
            
            return false;
        }

        public TweenSequence AddOnCompleteCallback(Action callback)
        {
            if (callback != null)
            {
                OnCompleteCallback += callback;
            }
            
            return this;
        }
        
        public TweenSequence Reset()
        {
            _isPlaying = false;
            _elapsedTime = 0;
            _lastTweenDelay = 0;
            _tweens.Clear();
            return this;
        }
    }
}