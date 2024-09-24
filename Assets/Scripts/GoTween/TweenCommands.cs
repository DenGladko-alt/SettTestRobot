using System;
using UnityEngine;

namespace GoTween
{
    [Serializable]
    public struct TweenCommand
    {
        public TweenType tweenType;
        public EaseType easeType;
        public float duration;
        public Vector3 value;
        public Color color; // Used only for Color tween
    }
}