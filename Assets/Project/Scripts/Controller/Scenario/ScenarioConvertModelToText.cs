using Project.Scripts.Controller.Utils;
using Project.Scripts.Model.ScenarioComponents;

namespace Project.Scripts.Controller.Scenario
{
	public class ScenarioConvertModelToText
	{
		private ScenarioStringUtils _scenarioStringUtils = new ScenarioStringUtils();
		
		public string GetScenarioText(Model.ScenarioComponents.Scenario scenario)
		{
			string result = $"{scenario.Title}[{scenario.Description}]\n";
			ScenarioGroup[] groupSteps = scenario.Groups;
			for (int groupIndex = 0; groupIndex < groupSteps.Length; groupIndex++)
				result += $"{groupIndex}. { GetGroupText(groupSteps[groupIndex], groupIndex) }";

			return result;
		}

		public string GetGroupText(ScenarioGroup group, int groupIndex = -1)
		{
			string result = $"{ group.Title }[{ group.Description }]\n";
			
			for (int stepIndex = 0; stepIndex < group.Steps.Length; stepIndex++)
			{
				string index = $"{(groupIndex == -1 ? "~" : groupIndex)}.{stepIndex}";
				result += $"{ index }) { group.Steps[stepIndex].Title }[{ group.Steps[stepIndex].Description }]\n";
				for (int actionIndex = 0; actionIndex < group.Steps[stepIndex].Actions.Length; actionIndex++)
				{
					result += $"{ index }.{ actionIndex }) { group.Steps[stepIndex].Actions[actionIndex].Description }\n";
				}
			}
			return result;
		}

		public string GetGroupActualStatusText(ScenarioGroup group, int groupIndex = -1)
		{
			string result = $"[{ group.Status }]" +
			                $"{ group.Title }[{ group.Description }]\n";
			
			for (int stepIndex = 0; stepIndex < group.Steps.Length; stepIndex++)
			{
				string index = $"{(groupIndex == -1 ? "~" : groupIndex)}.{stepIndex}";
				result += $"[{ group.Steps[stepIndex].Status }]" +
				          $"{ index }) { group.Steps[stepIndex].Title }[{ group.Steps[stepIndex].Description }]\n";
				for (int actionIndex = 0; actionIndex < group.Steps[stepIndex].Actions.Length; actionIndex++)
				{
					result += $"[{ group.Steps[stepIndex].Actions[actionIndex].Status }]" +
					          $"{ index }.{ actionIndex }) { group.Steps[stepIndex].Actions[actionIndex].Description }\n";
				}
			}
			return result;
		}
	}
}