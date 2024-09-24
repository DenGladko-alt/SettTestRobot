# GoTween Documentation

## Overview
GoTween is a tweening library similar to DOTween. It offers easy-to-use functions for moving, rotating, scaling and changing the color of objects. The library supports various easing functions for different kinds of interpolations between values.

## Key Features
- **Easy-to-Use Functions**: Move, rotate, scale, and change the color of objects.
- **Easing**: Apply different easing functions for smooth interpolations.
- **Chaining**: Flexibly adjust each tween by setting ease types or adding callbacks.
- **Sequences**: Create lists of tweens to run consecutively or concurrently.

## Example Usage

### Simple Tween Example:
```csharp
transform.MoveTo(new Vector3(10, 4.5f, 7.3f), 5f)
    .SetEase(EaseType.OutBounce)
    .AddOnCompleteCallback(() => Debug.Log("Tween completed"));
```

### Tween Sequences:
Sequences allow you to create a series of tweens that execute one after another. They can also include delays or run multiple tweens simultaneously, such as rotating and changing color while moving.

```csharp
TweenSequence someSequence = new TweenSequence()
    .Append(transform.MoveTo(new Vector3(2f, 3f, 1f), 2.4f).SetEase(EaseType.Linear))
    .Append(transform.MoveTo(new Vector3(1f, 7f, 99f), 4f).SetEase(EaseType.InBounce))
    // Additional tweens can be added here
    .Play(); // Execute the sequence when ready, we can Play it later
```

You also have the option to chain tweens directly, instead of using `TweenSequence`.

ExampleScene include a "Robot" with a `RobotController` script that holds a list of `Instructions`. `Instructions` represent a list of commands that will be put into a `TweenSequence` and executed one by one. "Robot" also has a `RobotInstructionsDebugger` that will draw gizmos for visual representations of path that "Robot" will take with current `Instructions`.
New `Instructions` can be created with Create menu -> Data -> Robot Instructions.
