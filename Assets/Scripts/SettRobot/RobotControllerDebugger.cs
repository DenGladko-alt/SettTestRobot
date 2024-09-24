#if UNITY_EDITOR

using System.Collections.Generic;
using GoTween;
using UnityEditor;
using UnityEngine;

namespace SettRobot
{
    [RequireComponent(typeof(RobotController))]
    public class RobotInstructionsDebugger : MonoBehaviour
    {
        [SerializeField] private bool showDebug = true;
    
        [Header("Position")]
        [SerializeField] private float arrowSize = 0.5f;
        [SerializeField] private Color arrowColor = Color.green;
    
        [Header("Rotation")]
        [SerializeField] private float rotationRadius = 1f;
        [SerializeField] private Color rotationColor = Color.red;
    
        private RobotController _robot;

        private List<RobotInstructionSO> _instructions;

        private void OnValidate()
        {
            _robot = GetComponent<RobotController>();
            _instructions = _robot.Instructions;
        }

        private void OnDrawGizmos()
        {
            if (EditorApplication.isPlaying || !showDebug) return;
            
            Vector3 startPosition = transform.position;
            // Iterate through instructions and draw arrows/rotation indicators
            foreach (RobotInstructionSO instruction in _instructions)
            {
                foreach (TweenCommand tweenCommand in instruction.commands)
                {
                    switch (tweenCommand.tweenType)
                    {
                        case TweenType.MoveTo:
                            DrawArrow(startPosition, tweenCommand.value);
                            startPosition = tweenCommand.value;
                            break;
                        case TweenType.MoveBy:
                            DrawArrow(startPosition, startPosition + tweenCommand.value);
                            startPosition += tweenCommand.value;
                            break;
                        case TweenType.RotateTo or TweenType.RotateBy:
                            DrawRotationIndicator(startPosition);
                            break;
                    }
                }
            }
        }
    
        private void DrawArrow(Vector3 start, Vector3 end)
        {
            Gizmos.color = arrowColor;
            Gizmos.DrawLine(start, end);
            Vector3 direction = end - start;
    
            // Draw arrow head
            Vector3 right = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 + 20, 0) * Vector3.forward;
            Vector3 left = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 - 20, 0) * Vector3.forward;
            Gizmos.DrawRay(end, right * arrowSize);
            Gizmos.DrawRay(end, left * arrowSize);
        }
    
        private void DrawRotationIndicator(Vector3 position)
        {
            Gizmos.color = rotationColor;
            Handles.color = rotationColor;
            Handles.DrawWireDisc(position, Vector3.up, rotationRadius);
        }
    }
}

#endif
