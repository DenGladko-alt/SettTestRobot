using System.Collections.Generic;
using UnityEngine;
using GoTween;

namespace SettRobot
{
    [CreateAssetMenu(fileName = "RobotInstructions", menuName = "Data/Robot Instructions", order = 1)]
    public class RobotInstructionSO : ScriptableObject
    {
        public List<TweenCommand> commands = new List<TweenCommand>();
    }
}