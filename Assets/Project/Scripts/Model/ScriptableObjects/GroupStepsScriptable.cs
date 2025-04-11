using UnityEngine;

namespace Project.Scripts.Model.ScriptableObjects
{
	[CreateAssetMenu(fileName = "GroupStepsScriptable", menuName = "ScriptableObjects/Scenario/GroupStepsScriptable", order = 2)]
	// Group from scenarios
	public class GroupStepsScriptable : ScriptableObject
	{
		public StepScriptable[] Steps;
	}
}
