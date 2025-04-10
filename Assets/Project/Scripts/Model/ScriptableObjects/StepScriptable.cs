using UnityEngine;

namespace Project.Scripts.Model.ScriptableObjects
{
	[CreateAssetMenu(fileName = "StepScriptable", menuName = "ScriptableObjects/Scenario/StepScriptable", order = 3)]
	public class StepScriptable : ScriptableObject
	{
		public StepActionScriptable[] StepActions;
	}
}
