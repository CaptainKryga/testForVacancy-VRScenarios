using UnityEngine;

namespace Project.Scripts.Model.ScriptableObjects.Scenario
{
	[CreateAssetMenu(fileName = "ScenarioStepScriptable", 
		menuName = "ScriptableObjects/Scenario/ScenarioStepScriptable", order = 3)]
	// Step from group
	public class ScenarioStepScriptable : ScriptableObject
	{
		public string Title;
		public string Description;
		public ScenarioActionScriptable[] Actions;
	}
}
