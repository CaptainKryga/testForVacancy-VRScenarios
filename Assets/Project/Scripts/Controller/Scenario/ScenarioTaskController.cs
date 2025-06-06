using System.Collections.Generic;
using System.Linq;
using Project.Scripts.Model.ScenarioComponents;
using Project.Scripts.Model.ScriptableObjects.Scenario;
using Project.Scripts.View.TrainingRoom;
using UnityEngine;

namespace Project.Scripts.Controller.Scenario
{
	// Controller task's
	public class ScenarioTaskController : MonoBehaviour
	{
		private List<ScenarioAction> _actionListBase = new List<ScenarioAction>();
		private List<ScenarioAction> _actionList = new List<ScenarioAction>();
		private List<ScenarioStep> _stepList = new List<ScenarioStep>();
		private List<ScenarioGroup> _groupList = new List<ScenarioGroup>();
		private Model.ScenarioComponents.Scenario _scenario;

		// Controller sound actions
		[SerializeField] private ScenarioSoundView _scenarioSoundView;
		// Controller outline visible
		[SerializeField] private ScenarioOutlineController _scenarioOutlineController;

		// Actual groupId
		public int GetActualGroup => _groupId;
		private int _groupId;

		public void Init(Model.ScenarioComponents.Scenario scenario)
		{
			_scenario = scenario;
			GetAllActionFromTurn();
			
			scenario.Status = ScenarioStatusEnum.Started;
			_groupList[0].Status = ScenarioStatusEnum.Started;
			_stepList[0].Status = ScenarioStatusEnum.Started;
			_actionListBase[0].Status = ScenarioStatusEnum.Started;
			_scenarioOutlineController.UpdateOutlines(_actionListBase[0].Link);
		}

		// Get all task's in turn
		private void GetAllActionFromTurn()
		{
			foreach (var group in _scenario.Groups)
			{
				_groupList.Add(group);
				foreach (var step in group.Steps)
				{
					_stepList.Add(step);
					foreach (var action in step.Actions)
					{
						_actionListBase.Add(action);
					}
				}
			}
		}

		// Checking task execution
		public bool Complete(ScenarioActionScriptable link)
		{
			// Return if end training
			if (_groupId >= _scenario.Groups.Length)
				return false;
			
			// Else if task's from check?
			if (CheckTaskInGroup(link))
				return false;
			
			// List skip or fail groups
			_actionList = new List<ScenarioAction>();
			_stepList = new List<ScenarioStep>();
			_groupList = new List<ScenarioGroup>();

			// Find now task and correct list
			UpdateGroup(_scenario.Groups[_groupId], link);
			
			// If now group complete
			if (!(_scenario.Groups[_groupId].Status is ScenarioStatusEnum.Started or ScenarioStatusEnum.NotStarted))
			{
				_groupId++;
				if (_groupId < _scenario.Groups.Length)
					_scenario.Groups[_groupId].Status = ScenarioStatusEnum.Started;
				else
				{
					_scenarioOutlineController.UpdateOutlines(null);
					return true;
				}
			}
			
			// Update data list
			for (int x = 0; x < _actionList.Count; x++)
			{
				_actionListBase.Remove(_actionList[x]);
				_actionList[x].Status = _stepList.Count > 0 ? ScenarioStatusEnum.Skipped : ScenarioStatusEnum.Failure;
			}
			for (int x = 0; x < _stepList.Count; x++)
				_stepList[x].Status = _stepList.Count > 0 ? ScenarioStatusEnum.Skipped : ScenarioStatusEnum.Failure;
			for (int x = 0; x < _groupList.Count; x++)
				_groupList[x].Status = ScenarioStatusEnum.Skipped;
			
			//Sound fail
			if (_groupList.Count > 0 || _actionList.Count > 0 || _stepList.Count > 0)
				_scenarioSoundView.PlaySuccess(false);
			//Sound success
			else
				_scenarioSoundView.PlaySuccess(true);
			
			// Outline visible
			if (_actionListBase.Count > 0)
				_scenarioOutlineController.UpdateOutlines(_actionListBase[0].Link);
			
			return false;
		}

		// Check the list of actions, if the action is in the list then it launches update group, if not then exit
		private bool CheckTaskInGroup(ScenarioActionScriptable link)
		{
			var matches = _actionListBase.Count(p => p.Link == link);
			if (matches == 0)
				return true;
			return false;
		}

		// Check and Update Actual group
		private bool UpdateGroup(ScenarioGroup group, ScenarioActionScriptable link)
		{
			for (int x = 0; x < group.Steps.Length; x++)
			{
				if (group.Steps[x].Status is ScenarioStatusEnum.NotStarted)
				{
					group.Steps[x].Status = ScenarioStatusEnum.Started;
				}
				
				if (group.Steps[x].Status is ScenarioStatusEnum.Started &&
				    UpdateStep(group.Steps[x], link))
				{
					if (x == group.Steps.Length - 1 && !(group.Steps[x].Actions[^1].Status is ScenarioStatusEnum.Started or ScenarioStatusEnum.NotStarted))
					{
						group.Status = GetStatusFromArray(group.Steps.Select(step => step.Status).ToArray());
					}
					else if (x + 1 < group.Steps.Length)
					{
						group.Steps[x + 1].Status = ScenarioStatusEnum.Started;
						group.Steps[x + 1].Actions[0].Status = ScenarioStatusEnum.Started;
					}
					return true;
				}
			}

			_groupList.Add(group);
			return false;
		}

		// Check and Update Actual step
		private bool UpdateStep(ScenarioStep step, ScenarioActionScriptable link)
		{
			for (int x = 0; x < step.Actions.Length; x++)
			{
				if (step.Actions[x].Status is ScenarioStatusEnum.NotStarted)
				{
					step.Actions[x].Status = ScenarioStatusEnum.Started;
				}
				
				if (step.Actions[x].Status is ScenarioStatusEnum.Started &&
				    UpdateAction(step.Actions[x], link))
				{
					if (x == step.Actions.Length - 1)
					{
						step.Status = GetStatusFromArray(step.Actions.Select(action => action.Status).ToArray());
					}
					else if (x + 1 < step.Actions.Length)
					{
						step.Actions[x + 1].Status = ScenarioStatusEnum.Started;
					}

					return true;
				}
			}

			_stepList.Add(step);
			return false;
		}

		// Check and Update Actual action
		private bool UpdateAction(ScenarioAction action, ScenarioActionScriptable link)
		{
			if (action.Link == link)
			{
				_actionListBase.Remove(action);
				action.Status = ScenarioStatusEnum.Success;
				return true;
			}
			
			_actionList.Add(action);
			return false;
		}
		
		// Get average status from Array
		private ScenarioStatusEnum GetStatusFromArray(ScenarioStatusEnum[] statuses)
		{
			for (int x = 0; x < statuses.Length; x++)
			{
				if (statuses[x] == ScenarioStatusEnum.Failure)
					return ScenarioStatusEnum.Failure;
				else if (statuses[x] == ScenarioStatusEnum.Skipped)
					return ScenarioStatusEnum.Skipped;
			}

			return ScenarioStatusEnum.Success;
		}

		// Get actual id step
		public int GetActualStep(ScenarioGroup group)
		{
			for (int x = 0; x < group.Steps.Length; x++)
			{
				if (group.Steps[x].Status == ScenarioStatusEnum.Started)
					return x;
			}

			return group.Steps.Length - 1;
		}

		// Get final stats from user
		public string GetFinalStats()
		{
			string result = $"Сценарий: { _scenario.Title } \n" +
			                $"Описание: { _scenario.Description }\n";
			for (int x = 0; x < _scenario.Groups.Length; x++)
			{
				result += $"Группа { _scenario.Groups[x].Title } ({ _scenario.Groups[x].Description }) результат: { _scenario.Groups[x].Status }\n";
				for (int indexStep = 0; indexStep < _scenario.Groups[x].Steps.Length; indexStep++)
					result += $"Шаг { _scenario.Groups[x].Steps[indexStep].Title } ({ _scenario.Groups[x].Steps[indexStep].Description }) результат: { _scenario.Groups[x].Steps[indexStep].Status }\n";
			}
			return result;
		}
	}
}