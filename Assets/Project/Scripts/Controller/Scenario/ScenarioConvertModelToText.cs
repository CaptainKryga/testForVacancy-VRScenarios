using Project.Scripts.Model.ScriptableObjects;

namespace Project.Scripts.Controller.Scenario
{
	public class ScenarioConvertModelToText
	{
		public string GetScenarioText(ScenarioScriptable scenarioScriptable)
		{
			string result = scenarioScriptable.name;
			GroupStepsScriptable[] groupSteps = scenarioScriptable.GroupSteps;
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