using Project.Scripts.Controller.Scenario;
using Project.Scripts.Model;
using Project.Scripts.Model.ScriptableObjects;
using UnityEngine;

namespace Project.Scripts.Controller.TrainingRoom
{
	// Main controller Training Room
	public class TrainingRoomController : MonoBehaviour
	{
		// Scenario controller from Init logic
		[SerializeField] private ScenarioController _scenarioController;
		
		// Debug scenario from launch training room without main menu
		[SerializeField] private ScenarioScriptable _debugScenario;

		private void Awake()
		{
			// Check scenario == null?
			if (ScenarioModel.ScenarioScriptable == null)
				ScenarioModel.ScenarioScriptable = _debugScenario;
			
			// Scenario init, load data and setup
			_scenarioController.Init();
		}
	}
}
