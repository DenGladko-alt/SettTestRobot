using System;
using System.Collections.Generic;
using GoTween;
using UnityEngine;

namespace SettRobot
{
    public class RobotController : MonoBehaviour
    {
        [SerializeField] private List<RobotInstructionSO> _instructions;
    
        private Material _meshRendererMaterial;
        private int _currentInstructionIndex = 0;

        public List<RobotInstructionSO> Instructions => _instructions;

        private void Awake()
        {
            _meshRendererMaterial = GetComponent<MeshRenderer>().material;
        }

        private void Start()
        {
            ExecuteNextInstruction();
        }

        private void ExecuteNextInstruction()
        {
            if (_instructions == null || _instructions.Count == 0)
            {
                Debug.LogWarning("No instructions to execute");
                return;
            }
        
            if (_currentInstructionIndex >= _instructions.Count)
            {
                Debug.Log("All instructions have been executed");
                return;
            }
        
            TweenSequence sequence = new TweenSequence();
            foreach (TweenCommand tweenCommand in _instructions[_currentInstructionIndex].commands)
            {
                AppendTweenCommand(sequence, tweenCommand);
            }
        
            sequence.AddOnCompleteCallback(() =>
            {
                _currentInstructionIndex++;
                ExecuteNextInstruction();
            });
    
            sequence.Play();
        }

        private void AppendTweenCommand(TweenSequence sequence, TweenCommand tweenCommand)
        {
            switch (tweenCommand.tweenType)
            {
                case TweenType.MoveTo:
                    sequence.Append(transform.MoveTo(tweenCommand.value, tweenCommand.duration)
                        .SetEase(tweenCommand.easeType));
                    break;
                case TweenType.MoveBy:
                    sequence.Append(transform.MoveBy(tweenCommand.value, tweenCommand.duration)
                        .SetEase(tweenCommand.easeType));
                    break;
                case TweenType.RotateTo:
                    sequence.Append(transform.RotateTo(tweenCommand.value, tweenCommand.duration)
                        .SetEase(tweenCommand.easeType));
                    break;
                case TweenType.RotateBy:
                    sequence.Append(transform.RotateBy(tweenCommand.value, tweenCommand.duration)
                        .SetEase(tweenCommand.easeType));
                    break;
                case TweenType.ScaleTo:
                    sequence.Append(transform.ScaleTo(tweenCommand.value, tweenCommand.duration)
                        .SetEase(tweenCommand.easeType));
                    break;
                case TweenType.ScaleBy:
                    sequence.Append(transform.ScaleBy(tweenCommand.value, tweenCommand.duration)
                        .SetEase(tweenCommand.easeType));
                    break;
                case TweenType.ColorTo:
                    sequence.Append(_meshRendererMaterial.ColorTo(tweenCommand.color, tweenCommand.duration)
                        .SetEase(tweenCommand.easeType));
                    break;
                default:
                    Debug.LogWarning("Unknown tween type");
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}