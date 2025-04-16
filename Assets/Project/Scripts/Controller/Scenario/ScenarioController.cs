using Project.Scripts.Global.Managers;
using Project.Scripts.Model;
using Project.Scripts.Model.ScriptableObjects.Scenario;
using Project.Scripts.View.TrainingRoom;
using UnityEngine;

namespace Project.Scripts.Controller.Scenario
{
	// Base scenario controller from all scene's
	public class ScenarioController : ControllerBaseAbstract
	{
		// View scenario
		[SerializeField] private UpdateViewAbstract<string> _scenarioListView;
		[SerializeField] private UpdateViewAbstract<string> _scenarioTaskView;
		[SerializeField] private UpdateViewAbstract<string> _scenarioTrainingEnd;

		// Converter model to text, scriptables to scripts
		private readonly ScenarioConvertModelToText _scenarioConvertModelToText = new ScenarioConvertModelToText();
		
		
		[SerializeField] private ScenarioTaskController _scenarioTaskController;
		
		public override void Init()
		{
			_scenarioTaskController.Init(ScenarioModel.Scenario);
			
			_scenarioListView.UpdateComponent(_scenarioConvertModelToText.GetScenarioText(ScenarioModel.Scenario));
			_scenarioTaskView.UpdateComponent(_scenarioConvertModelToText.GetScenarioText(ScenarioModel.Scenario));
		}

		private void OnEnable()
		{
			ScenarioManager.Instance.Listen(ScenarioType.Action, FuncAction);
		}

		private void OnDisable()
		{
			ScenarioManager.Instance.UnListen(ScenarioType.Action, FuncAction);
		}

		private void FuncAction(object obj)
		{
			if (_scenarioTaskController.Complete((ScenarioActionScriptable) obj))
			{
				_scenarioTrainingEnd.UpdateComponent("End");
			}
			
			_scenarioListView.UpdateComponent(_scenarioConvertModelToText.GetScenarioText(ScenarioModel.Scenario));
			_scenarioTaskView.UpdateComponent(_scenarioConvertModelToText.GetScenarioText(ScenarioModel.Scenario));
		}
	}
}
