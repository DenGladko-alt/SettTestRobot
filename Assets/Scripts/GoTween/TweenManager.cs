// The TweenManager is responsible for managing and updating all tweens and sequences.
// It provides functionality to add, remove and update them.

using UnityEngine;
using System.Collections.Generic;

namespace GoTween
{
    public class TweenManager : MonoBehaviour
    {
        private const string NAME_OF_NEW_MANAGER = "[TweenManager]";
        
        private static TweenManager _instance;
        
        // TODO: Add pooling
        private List<TweenSequence> _sequencesList = new List<TweenSequence>();
        private List<Tween> _tweensList = new List<Tween>();

        public static TweenManager Instance => _instance ?? FindOrCreateInstance();

        private static TweenManager FindOrCreateInstance()
        {
            TweenManager instance = FindObjectOfType<TweenManager>();
            if (instance != null)
            {
                _instance = instance;
                return _instance;
            }

            GameObject tweenManager = new GameObject(NAME_OF_NEW_MANAGER);
            _instance = tweenManager.AddComponent<TweenManager>();

            DontDestroyOnLoad(tweenManager);
            return _instance;
        }

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            float deltaTime = Time.deltaTime;

            for (int i = _sequencesList.Count - 1; i >= 0; i--)
            {
                if (_sequencesList[i].UpdateSequence(deltaTime))
                {
                    _sequencesList.Remove(_sequencesList[i]);
                }
            }

            for (int i = _tweensList.Count - 1; i >= 0; i--)
            {
                if (_tweensList[i].UpdateTween(deltaTime))
                {
                    _tweensList.Remove(_tweensList[i]);
                }
            }
        }

        public void AddTween(Tween tween)
        {
            if (tween == null)
            {
                Debug.LogWarning("Attempted to add a null Tween to the active tweens list.");
                return;
            }
    
            _tweensList.Add(tween);
        }

        public void RemoveTween(Tween tween)
        {
            _tweensList.Remove(tween);
        }

        public void AddSequence(TweenSequence sequence)
        {
            if (sequence == null)
            {
                Debug.LogWarning("Attempted to add a null Sequence to the active sequences list.");
                return;
            }
            
            _sequencesList.Add(sequence);
        }

        public void RemoveSequence(TweenSequence sequence)
        {
            _sequencesList.Remove(sequence);
        }
    }
}