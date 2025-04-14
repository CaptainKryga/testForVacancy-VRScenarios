using UnityEngine;

namespace Project.Scripts.Model.ScriptableObjects.Scenario
{
	[CreateAssetMenu(fileName = "ScenarioGroupScriptable", 
		menuName = "ScriptableObjects/Scenario/ScenarioGroupScriptable", order = 2)]
	// Group from scenarios
	public class ScenarioGroupScriptable : ScriptableObject
	{
		public string Title;
		public string Description;
		public ScenarioStepScriptable[] Steps;
	}
}
