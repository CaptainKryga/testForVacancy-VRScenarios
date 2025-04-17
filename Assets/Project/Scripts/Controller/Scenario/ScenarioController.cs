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
		// Main task processing controller
		[SerializeField] private ScenarioTaskController _scenarioTaskController;
		
		private void OnEnable()
		{
			ScenarioManager.Instance.Listen(ScenarioType.Action, FuncAction);
		}

		private void OnDisable()
		{
			ScenarioManager.Instance.UnListen(ScenarioType.Action, FuncAction);
		}
		
		public override void Init()
		{
			_scenarioTaskController.Init(ScenarioModel.Scenario);
			_scenarioTitleView.UpdateComponent($"Название: {ScenarioModel.Scenario.Title}\n" +
			                                   $"Описание: {ScenarioModel.Scenario.Description}\n" +
			                                   $"Количество групп: {ScenarioModel.Scenario.Groups.Length}");
			
			UpdateUI();
		}

		// Method that handles input of links in a scene that are task actions
		private void FuncAction(object obj)
		{
			if (_scenarioTaskController.Complete((ScenarioActionScriptable) obj))
			{
				_scenarioTrainingEnd.UpdateComponent(_scenarioTaskController.GetFinalStats());
			}
			else
			{
				UpdateUI();
			}
		}
		
		// UI user update
		private void UpdateUI()
		{
			int groupActualId = _scenarioTaskController.GetActualGroup;
			ScenarioGroup group = ScenarioModel.Scenario.Groups[groupActualId];
			int stepActualId = _scenarioTaskController.GetActualStep(group);
			
			_scenarioScenarioView.UpdateComponent($"Текущая группа { groupActualId }\n" + 
			                                      _scenarioConvertModelToText.GetGroupActualStatusText(group, groupActualId));
			_scenarioGroupView.UpdateComponent($"Текущий шаг { stepActualId }\n" + 
			                                   _scenarioConvertModelToText.GetStepActualStatusText(group.Steps[stepActualId], $"{groupActualId}.{stepActualId}"));
		}

		// Method that handles input of links in a scene that are task actions
		public void OnAction_Action(ScenarioActionScriptable link)
		{
			FuncAction(link);
		}
	}
}
