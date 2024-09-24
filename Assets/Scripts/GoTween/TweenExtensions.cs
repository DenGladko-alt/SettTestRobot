using System;
using UnityEngine;

namespace GoTween
{
    public static class TweenExtensions
    {
        // Move
        public static Tween MoveTo(this Transform transform, Vector3 endValue, float duration)
        {
            bool started = false;
            Vector3 startPosition = transform.position;

            return new Tween(
                (progress) => {
                    if (!started)
                    {
                        startPosition = transform.position;
                        started = true;
                    }
                    transform.position = Vector3.Lerp(startPosition, endValue, progress);
                },
                duration);
        }
        
        public static Tween MoveBy(this Transform transform, Vector3 offset, float duration)
        {
            bool started = false;
            Vector3 startPosition = transform.position;
            Vector3 endPosition = transform.position + offset;

            return new Tween(
                (progress) => {
                    if (!started)
                    {
                        startPosition = transform.position;
                        endPosition = transform.position + offset;
                        started = true;
                    }
                    transform.position = Vector3.Lerp(startPosition, endPosition, progress);
                },
                duration);
        }

        // Rotate
        public static Tween RotateTo(this Transform transform, Vector3 endValue, float duration)
        {
            bool started = false;
            Quaternion startRotation = transform.rotation;
            Quaternion endRotation = Quaternion.Euler(endValue);

            return new Tween(
                (progress) => {
                    if (!started)
                    {
                        startRotation = transform.rotation;
                        endRotation = Quaternion.Euler(endValue);
                        started = true;
                    }
                    transform.rotation = Quaternion.Lerp(startRotation, endRotation, progress);
                },
                duration);
        }
        public static Tween RotateBy(this Transform transform, Vector3 offset, float duration)
        {
            bool started = false;
            Quaternion startRotation = transform.rotation;
            Quaternion endRotation = startRotation * Quaternion.Euler(offset);

            return new Tween(
                (progress) => {
                    if (!started)
                    {
                        startRotation = transform.rotation;
                        endRotation = startRotation * Quaternion.Euler(offset);
                        started = true;
                    }
                    transform.rotation = Quaternion.Lerp(startRotation, endRotation, progress);
                },
                duration);
        }
        

        // Scale
        public static Tween ScaleTo(this Transform transform, Vector3 endValue, float duration)
        {
            bool started = false;
            Vector3 startScale = transform.localScale;

            return new Tween(
                (progress) => {
                    if (!started)
                    {
                        startScale = transform.localScale;
                        started = true;
                    }
                    transform.localScale = Vector3.Lerp(startScale, endValue, progress);
                },
                duration);
        }
        
        public static Tween ScaleBy(this Transform transform, Vector3 offset, float duration)
        {
            bool started = false;
            Vector3 startScale = transform.localScale;
            Vector3 endScale = startScale + offset;

            return new Tween(
                (progress) => {
                    if (!started)
                    {
                        startScale = transform.localScale;
                        endScale = startScale + offset;
                        started = true;
                    }
                    transform.localScale = Vector3.Lerp(startScale, endScale, progress);
                },
                duration);
        }

        // Material || Color
        public static Tween ColorTo(this Material material, Color endValue, float duration)
        {
            bool started = false;
            Color startColor = material.color;

            return new Tween(
                (progress) => {
                    if (!started)
                    {
                        startColor = material.color;
                        started = true;
                    }
                    material.color = Color.Lerp(startColor, endValue, progress);
                },
                duration);
        }
    }
}