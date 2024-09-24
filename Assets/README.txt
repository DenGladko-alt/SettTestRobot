GoTween Documentation

Overview
GoTween is a tweening library similar to DOTween. It has easy to use functions for moving, rotating, scaling, changing color of objects. It can use Easing for different interpolations betweens values.
It also support chaining and sequences. Chaining allow to flexible adjust each Tween, for example setting Ease type or adding callbacks.

Example of simple Tween:
transform.MoveTo(new Vector3(10, 4.5f, 7.3f), 5f)
	.SetEase(EaseType.OutBounce)
        .AddOnCompleteCallback(() => Debug.Log("Tween completed"));

Sequences allow to create a list of Tweens that will be executed one by one, but it can also be used to add delays or executing two or more Tweens at the same time, for example rotating and changing color while moving.

TweenSequence someSequence = new TweenSequence()
	.Append(transform.MoveTo(new Vector3(2f,3f,1f), 2.4f).SetEase(EaseType.Linear))
	.Append(transform.MoveTo(new Vector3(1f,7f,99f), 4f).SetEase(EaseType.InBounce))
            // ....
	.Play(); // We can play sequence later when we want

You can also chain Tweens this way instead of using TweenSequences.

Each Tween and Sequence is updated by TweenManager acheiving optimisation.


GoTween example has a RobotController thay contain a List of Commands (TweenCommands). Each Command has a TweenType (like MoveTo, RotateBy, ColorTo etc., duration, endValue and Color for changing color). This is used for creating a TweenSequence that is Played. Each element can be adjusted from Inspector inside Unity editor. It also has RobotControllerDebugger for visual representation of Commands - for example showing path of sequenced MoveTo and MoveBy.