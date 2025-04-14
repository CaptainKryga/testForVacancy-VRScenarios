using Project.Scripts.Model;
using Project.Scripts.View.TrainingRoom;
using UnityEngine;

namespace Project.Scripts.Controller.Scenario
{
	// Base scenario controller from all scene's
	public class ScenarioController : ControllerBaseAbstract
	{
		// View scenario
		[SerializeField] private UpdateViewAbstract<string> updateListView;
		[SerializeField] private UpdateViewAbstract<string> updateTaskView;

		// Converter model to text
		private readonly ScenarioConvertModelToText _scenarioConvertModelToText = new ScenarioConvertModelToText();
		
		public override void Init()
		{
			updateListView.UpdateComponent(_scenarioConvertModelToText.GetScenarioText(ScenarioModel.ScenarioScriptable));
			updateTaskView.UpdateComponent(_scenarioConvertModelToText.GetScenarioText(ScenarioModel.ScenarioScriptable));
		}

		// Get string all scenario

	}
}
