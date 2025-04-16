using Project.Scripts.Global.Managers;
using Project.Scripts.Model;
using Project.Scripts.Model.ScenarioComponents;
using Project.Scripts.Model.ScriptableObjects.Scenario;
using Project.Scripts.View.TrainingRoom;
using UnityEngine;

namespace Project.Scripts.Controller.Scenario
{
	// Base scenario controller from all scene's
	public class ScenarioController : ControllerBaseAbstract
	{
		// View scenario
		[SerializeField] private UpdateViewAbstract<string> _scenarioTitleView;
		[SerializeField] private UpdateViewAbstract<string> _scenarioScenarioView;
		[SerializeField] private UpdateViewAbstract<string> _scenarioGroupView;
		[SerializeField] private UpdateViewAbstract<string> _scenarioTrainingEnd;

		// Converter model to text, scriptables to scripts
		private readonly ScenarioConvertModelToText _scenarioConvertModelToText = new ScenarioConvertModelToText();
		
		
		[SerializeField] private ScenarioTaskController _scenarioTaskController;
		
		public override void Init()
		{
			_scenarioTaskController.Init(ScenarioModel.Scenario);
			
			_scenarioTitleView.UpdateComponent($"{ScenarioModel.Scenario.Title}\n{ScenarioModel.Scenario.Description}");
			
			_scenarioScenarioView.UpdateComponent("Текущий сценарий:\n" + 
			                                      _scenarioConvertModelToText.GetScenarioText(ScenarioModel.Scenario));
			
			_scenarioGroupView.UpdateComponent("Текущая группа:\n" + 
			                                   _scenarioConvertModelToText.GetGroupText(ScenarioModel.Scenario.Groups[0], 0));
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

			// await Task.Delay(100);
			// _scenarioScenarioView.UpdateComponent(_scenarioConvertModelToText.GetScenarioText(ScenarioModel.Scenario));
			int groupActualId = _scenarioTaskController.GetActualGroup();
			ScenarioGroup group = ScenarioModel.Scenario.Groups[groupActualId];
			// await Task.Delay(100);
			_scenarioGroupView.UpdateComponent("Текущая группа:\n" + _scenarioConvertModelToText.GetGroupActualStatusText(group, groupActualId));
		}
	}
}
