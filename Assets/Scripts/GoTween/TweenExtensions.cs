using UnityEngine;

namespace GoTween
{
    /// <summary>
    /// A static class containing extension methods for tweening Transforms and Materials in Unity.
    /// </summary>
    public static class TweenExtensions
    {
        // Move
        /// Move the Transform to the specified end position over the given duration.
        /// <param name="transform">The Transform to be moved.</param>
        /// <param name="endValue">The target position to move the Transform to.</param>
        /// <param name="duration">The time duration over which the movement occurs.</param>
        /// <return>A Tween object that represents the animation.</return>
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

        /// <summary>
        /// Moves the transform by the specified offset over a set duration.
        /// </summary>
        /// <param name="transform">The transform to move.</param>
        /// <param name="offset">The offset by which to move the transform.</param>
        /// <param name="duration">The time duration over which to move the transform.</param>
        /// <returns>A Tween object representing the animation.</returns>
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
        /// <summary>
        /// Rotates the Transform to the specified rotation over the given duration.
        /// </summary>
        /// <param name="transform">The Transform to be rotated.</param>
        /// <param name="endValue">The target rotation as a Vector3.</param>
        /// <param name="duration">The duration over which the rotation occurs.</param>
        /// <returns>A Tween object that can be used to control the animation.</returns>
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

        /// <summary>
        /// Rotates the transform by the specified offset over the given duration.
        /// </summary>
        /// <param name="transform">The transform to rotate.</param>
        /// <param name="offset">The amount to rotate by (Euler angles).</param>
        /// <param name="duration">The duration of the rotation in seconds.</param>
        /// <returns>A tween object representing the rotation.</returns>
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
        /// <summary>
        /// Animates the scaling of the transform to the specified end value over the given duration.
        /// </summary>
        /// <param name="transform">The transform to be scaled.</param>
        /// <param name="endValue">The target scale value.</param>
        /// <param name="duration">The duration of the scaling animation.</param>
        /// <returns>A Tween object representing the scaling animation.</returns>
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

        /// <summary>
        /// Scales the transform by the specified offset over the given duration.
        /// </summary>
        /// <param name="transform">The transform to be scaled.</param>
        /// <param name="offset">The offset by which to scale the transform.</param>
        /// <param name="duration">The duration over which the scaling will occur.</param>
        /// <returns>A Tween object that represents the scaling operation.</returns>
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
        /// Tween material color from its current color to the specified end value over the given duration.
        /// <param name="material">The material whose color will be tweened.</param>
        /// <param name="endValue">The target color to tween to.</param>
        /// <param name="duration">The duration over which the tween takes place.</param>
        /// <return>A Tween object that can be used to control the animation.</return>
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