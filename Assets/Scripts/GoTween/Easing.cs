// The Easing class offers a collection of easing functions used in animations to create smooth transitions.
// It includes methods like Linear, Sine, Quad, Cubic, Quart, Quint, Expo, Circ, Back, Elastic and Bounce.
// Each with variations for different easing effects (In, Out, InOut).
// Visual representation can be found here: https://easings.net/

using System;
using UnityEngine;

namespace GoTween
{
	public static class Easing
	{
		public static float GetEase(EaseType easeType, float t)
		{
			return easeType switch
			{
				EaseType.Linear => Linear(t),
				EaseType.InSine => InSine(t),
				EaseType.OutSine => OutSine(t),
				EaseType.InOutSine => InOutSine(t),
				EaseType.InQuad => InQuad(t),
				EaseType.OutQuad => OutQuad(t),
				EaseType.InOutQuad => InOutQuad(t),
				EaseType.InCubic => InCubic(t),
				EaseType.OutCubic => OutCubic(t),
				EaseType.InOutCubic => InOutCubic(t),
				EaseType.InQuart => InQuart(t),
				EaseType.OutQuart => OutQuart(t),
				EaseType.InOutQuart => InOutQuart(t),
				EaseType.InQuint => InQuint(t),
				EaseType.OutQuint => OutQuint(t),
				EaseType.InOutQuint => InOutQuint(t),
				EaseType.InExpo => InExpo(t),
				EaseType.OutExpo => OutExpo(t),
				EaseType.InOutExpo => InOutExpo(t),
				EaseType.InCirc => InCirc(t),
				EaseType.OutCirc => OutCirc(t),
				EaseType.InOutCirc => InOutCirc(t),
				EaseType.InBack => InBack(t),
				EaseType.OutBack => OutBack(t),
				EaseType.InOutBack => InOutBack(t),
				EaseType.InElastic => InElastic(t),
				EaseType.OutElastic => OutElastic(t),
				EaseType.InOutElastic => InOutElastic(t),
				EaseType.InBounce => InBounce(t),
				EaseType.OutBounce => OutBounce(t),
				EaseType.InOutBounce => InOutBounce(t),
				_ => t
			};
		}
		
		public static float Linear(float t) => t;
		

		#region === Sine ===
		
		public static float InSine(float t) => 1 - (float)Math.Cos(t * Math.PI / 2);
		public static float OutSine(float t) => (float)Math.Sin(t * Math.PI / 2);
		public static float InOutSine(float t) => (float)(Math.Cos(t * Math.PI) - 1) / -2;
		
		#endregion
		

		#region === Quad ===
		
		public static float InQuad(float t) => t * t;
		public static float OutQuad(float t) => 1 - InQuad(1 - t);
		public static float InOutQuad(float t)
		{
			t *= 2;
			if (t < 1) return 0.5f * t * t;
			t -= 1;
			return -0.5f * (t * (t - 2) - 1);
		}

		#endregion
		

		#region === Cubic ===
		
		public static float InCubic(float t) => t * t * t;
		public static float OutCubic(float t) => 1 - InCubic(1 - t);
		public static float InOutCubic(float t)
		{
			t *= 2;
			if (t < 1) return 0.5f * t * t * t;
			t -= 1;
			return 0.5f * (t * t * t + 1);
		}

		#endregion
		

		#region === Quart ===
		
		public static float InQuart(float t) => t * t * t * t;
		public static float OutQuart(float t) => 1 - InQuart(1 - t);
		public static float InOutQuart(float t)
		{
			t *= 2;
			if (t < 1) return 0.5f * t * t * t * t;
			t -= 1;
			return -0.5f * (t * t * t * t - 1);
		}

		#endregion
		

		#region === Quint ===
		
		public static float InQuint(float t) => t * t * t * t * t;
		
		public static float OutQuint(float t) => 1 - InQuint(1 - t);
		
		public static float InOutQuint(float t)
		{
			t *= 2;
			if (t < 1) return 0.5f * t * t * t * t * t;
			t -= 1;
			return 0.5f * (t * t * t * t * t + 1);
		}

		#endregion
		

		#region === Expo ===
		
		public static float InExpo(float t) => t == 0 ? 0 : 1 << (int)(10 * (t - 1));
		
		public static float OutExpo(float t) => 1 - (Mathf.Approximately(t, 1) ? 1 : (float)(1 << (int)(10 * (1 - t) - 1)));
		
		public static float InOutExpo(float t)
		{
			if (t <= 0) return 0;
			if (t >= 1) return 1;
			
			t *= 2;
			if (t < 1) return 0.5f * (float)Math.Pow(2, 10 * (t - 1));
			return 0.5f * (2 - (float)Math.Pow(2, -10 * (t - 1)));
		}

		#endregion
		

		#region === Circ ===
		
		public static float InCirc(float t) => -((float)Math.Sqrt(1 - t * t) - 1);
		
		public static float OutCirc(float t) => 1 - InCirc(1 - t);
		
		public static float InOutCirc(float t)
		{
			t *= 2;
			if (t < 1) return -0.5f * ((float)Math.Sqrt(1 - t * t) - 1);
			t -= 2;
			return 0.5f * ((float)Math.Sqrt(1 - t * t) + 1);
		}

		#endregion
		

		#region === Back ===
		
		public static float InBack(float t, float s = 1.70158f) => t * t * ((s + 1) * t - s);
		
		public static float OutBack(float t, float s = 1.70158f) =>  1 - InBack(1 - t, s);
		
		public static float InOutBack(float t, float s = 1.70158f)
		{
			float s2 = s * 1.525f;
			t *= 2;
			if (t < 1) return 0.5f * (t * t * ((s2 + 1) * t - s2));
			t -= 2;
			return 0.5f * (t * t * ((s2 + 1) * t + s2) + 2);
		}

		#endregion
		

		#region === Elastic ===
		
		public static float OutElastic(float t, float p = 0.3f, float s = 1.70158f) 
			=> (float)Math.Pow(2, -10 * t) * (float)Math.Sin((t - p / 4) * (2 * Math.PI) / p) + 1;
		
		public static float InElastic(float t, float p = 0.3f, float s = 1.70158f) => 1 - OutElastic(1 - t, p, s);
		
		public static float InOutElastic(float t, float p = 0.3f, float s = 1.70158f)
		{
			if (t < 0.5) return InElastic(t * 2, p, s) / 2;
			return 1 - InElastic((1 - t) * 2, p, s) / 2;
		}

		#endregion
		

		#region === Bounce ===
		
		public static float InBounce(float t) => 1 - OutBounce(1 - t);
		
		public static float OutBounce(float t)
		{
			float div = 2.75f;
			float mult = 7.5625f;

			if (t < 1 / div)
			{
				return mult * t * t;
			}
			if (t < 2 / div)
			{
				t -= 1.5f / div;
				return mult * t * t + 0.75f;
			}
			if (t < 2.5 / div)
			{
				t -= 2.25f / div;
				return mult * t * t + 0.9375f;
			}
			
			t -= 2.625f / div;
			return mult * t * t + 0.984375f;
		}
		
		public static float InOutBounce(float t)
		{
			if (t < 0.5) return InBounce(t * 2) / 2;
			return 1 - InBounce((1 - t) * 2) / 2;
		}

		#endregion
		
		// TODO: Add custom curve evaluation
	}
}
