using Project.Scripts.Model;
using Project.Scripts.Model.ScriptableObjects;
using Project.Scripts.View.TrainingRoom;
using UnityEngine;

namespace Project.Scripts.Controller.Scenario
{
	public class ScenarioController : ControllerBaseAbstract
	{
		// View scenario
		[SerializeField] private ScenarioListView _scenarioListView;
		
		public override void Init()
		{
			_scenarioListView.ScenarioInit(GetScenarioList());
		}

		// Get string all scenario
		private string GetScenarioList()
		{
			string result = ScenarioModel.ScenarioScriptable.name;
			GroupStepsScriptable[] groupSteps = ScenarioModel.ScenarioScriptable.GroupSteps;
			for (int groupIndex = 0; groupIndex < groupSteps.Length; groupIndex++)
			{
				result += groupSteps[groupIndex].name;
				for (int stepIndex = 0; stepIndex < groupSteps[groupIndex].Steps.Length; stepIndex++)
				{
					result += groupSteps[groupIndex].Steps[stepIndex].name;
					for (int actionIndex = 0; actionIndex < groupSteps[groupIndex].Steps[stepIndex].StepActions.Length; actionIndex++)
					{
						result += groupSteps[groupIndex].Steps[stepIndex].StepActions[actionIndex].name;
					}
				}
			}

			return result;
		}
	}
}
