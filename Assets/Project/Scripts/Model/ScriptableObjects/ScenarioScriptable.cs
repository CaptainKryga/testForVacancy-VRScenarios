using UnityEngine;

namespace Project.Scripts.Model.ScriptableObjects
{
	[CreateAssetMenu(fileName = "ScenarioScriptable", menuName = "ScriptableObjects/Scenario/ScenarioScriptable", order = 1)]
	public class ScenarioScriptable : ScriptableObject
	{
		public GroupStepsScriptable[] GroupSteps;
	}
}
