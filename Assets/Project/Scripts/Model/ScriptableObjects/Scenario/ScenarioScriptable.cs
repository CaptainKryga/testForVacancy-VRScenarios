using UnityEngine;

namespace Project.Scripts.Model.ScriptableObjects.Scenario
{
	[CreateAssetMenu(fileName = "ScenarioScriptable", menuName = "ScriptableObjects/Scenario/ScenarioScriptable", order = 1)]
	// Root scenario
	public class ScenarioScriptable : ScriptableObject
	{
		public string Title;
		public string Description;
		public ScenarioGroupScriptable[] GroupSteps;
	}
}
