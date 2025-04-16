using System.Collections.Generic;
using System.Linq;
using Project.Scripts.Model.ScenarioComponents;
using Project.Scripts.Model.ScriptableObjects.Scenario;
using UnityEngine;

namespace Project.Scripts.Controller.Scenario
{
	public class ScenarioTaskController : MonoBehaviour
	{
		private List<ScenarioAction> _actionListBase = new List<ScenarioAction>();
		private List<ScenarioAction> _actionList = new List<ScenarioAction>();
		private List<ScenarioStep> _stepList = new List<ScenarioStep>();
		private List<ScenarioGroup> _groupList = new List<ScenarioGroup>();
		private Model.ScenarioComponents.Scenario _scenario;

		public void Init(Model.ScenarioComponents.Scenario scenario)
		{
			_scenario = scenario;
			MappingTasks();
			
			scenario.Status = ScenarioStatusEnum.Started;
			_groupList[0].Status = ScenarioStatusEnum.Started;
			_stepList[0].Status = ScenarioStatusEnum.Started;
			_actionList[0].Status = ScenarioStatusEnum.Started;
		}

		private void MappingTasks()
		{
			foreach (var group in _scenario.Groups)
			{
				_groupList.Add(group);
				
				foreach (var step in group.Steps)
				{
					_stepList.Add(step);
					
					foreach (var action in step.Actions)
					{
						_actionList.Add(action);
						_actionListBase.Add(action);
					}	
				}
			}
		}
		
		// Checking task execution
		public bool Complete(ScenarioActionScriptable link)
		{
			if (CheckTaskInGroup(link))
				return false;
			
			_actionList = new List<ScenarioAction>();
			_stepList = new List<ScenarioStep>();
			_groupList = new List<ScenarioGroup>();
			
			UpdateScenario(link);

			for (int x = 0; x < _actionList.Count; x++)
			{
				_actionListBase.Remove(_actionList[x]);
				_actionList[x].Status = ScenarioStatusEnum.Skipped;
			}
			for (int x = 0; x < _stepList.Count; x++)
				_stepList[x].Status = ScenarioStatusEnum.Skipped;
			for (int x = 0; x < _groupList.Count; x++)
				_groupList[x].Status = ScenarioStatusEnum.Skipped;

			_scenario.Status = _scenario.Groups[^1].Steps[^1].Actions[^1].Status is
				ScenarioStatusEnum.NotStarted or ScenarioStatusEnum.Started ? ScenarioStatusEnum.Started : ScenarioStatusEnum.Success;
			
			
			return _scenario.Status == ScenarioStatusEnum.Success;
		}

		// Check the list of actions, if the action is in the list then it launches update group, if not then exit
		private bool CheckTaskInGroup(ScenarioActionScriptable link)
		{
			var matches = _actionListBase.Count(p => p.Link == link);
			if (matches == 0)
				return true;
			return false;
		}

		// return end scenario?
		private bool UpdateScenario(ScenarioActionScriptable link)
		{
			for (int x = 0; x < _scenario.Groups.Length; x++)
			{
				if (_scenario.Groups[x].Status is ScenarioStatusEnum.NotStarted)
				{
					_scenario.Groups[x].Status = ScenarioStatusEnum.Started;
				}
				
				if (_scenario.Groups[x].Status is ScenarioStatusEnum.Started &&
				    UpdateGroup(_scenario.Groups[x], link))
				{
					return true;
				}
			}
			
			return false;
		}

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
					if (x == group.Steps.Length - 1)
					{
						group.Status = group.Steps[^1].Status;
					}
					return true;
				}
			}

			_groupList.Add(group);
			return false;
		}

		private bool UpdateStep(ScenarioStep step, ScenarioActionScriptable link)
		{
			for (int x = 0; x < step.Actions.Length; x++)
			{
				if (step.Actions[x].Status is ScenarioStatusEnum.Started or ScenarioStatusEnum.NotStarted &&
				    UpdateAction(step.Actions[x], link))
				{
					if (x == step.Actions.Length - 1)
					{
						step.Status = step.Actions[^1].Status;
					}
					return true;
				}
			}

			_stepList.Add(step);
			return false;
		}

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
	}
}