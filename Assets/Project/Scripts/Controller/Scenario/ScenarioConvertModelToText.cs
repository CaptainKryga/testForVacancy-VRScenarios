using Project.Scripts.Controller.Utils;
using Project.Scripts.Model.ScenarioComponents;

namespace Project.Scripts.Controller.Scenario
{
	public class ScenarioConvertModelToText
	{
		// Get scenario all text
		public string GetScenarioText(Model.ScenarioComponents.Scenario scenario)
		{
			string result = $"{scenario.Title}[{scenario.Description}]\n";
			ScenarioGroup[] groupSteps = scenario.Groups;
			for (int groupIndex = 0; groupIndex < groupSteps.Length; groupIndex++)
				result += $"{groupIndex}. { GetGroupText(groupSteps[groupIndex], groupIndex) }";

			return result;
		}

		// Get one group text
		public string GetGroupText(ScenarioGroup group, int groupIndex = -1)
		{
			string result = $"{ group.Title }[{ group.Description }]\n";
			
			for (int stepIndex = 0; stepIndex < group.Steps.Length; stepIndex++)
			{
				string index = $"{(groupIndex == -1 ? "~" : groupIndex)}.{stepIndex}";
				result += $"{ index }) { group.Steps[stepIndex].Title }[{ group.Steps[stepIndex].Description }]\n";
				// for (int actionIndex = 0; actionIndex < group.Steps[stepIndex].Actions.Length; actionIndex++)
				// {
				// 	result += $"{ index }.{ actionIndex }) { group.Steps[stepIndex].Actions[actionIndex].Description }\n";
				// }
			}
			return result;
		}
		
		// Get one group text and status
		public string GetGroupActualStatusText(ScenarioGroup group, int groupIndex = -1)
		{
			string result = $"Название группы: { group.Title }\n" +
			                $"Описание группы: { group.Description }\n" +
			                $"Статус: { group.Status }\n\n";
			
			for (int stepIndex = 0; stepIndex < group.Steps.Length; stepIndex++)
			{
				string index = $"{stepIndex}";
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

		// Get one step text and status
		public string GetStepActualStatusText(ScenarioStep step, string indexParent)
		{
			string result = $"Название шага: { step.Title }\n" +
			                $"Описание шага: { step.Description }\n" +
			                $"Статус: { step.Status }\n\n";
			for (int actionIndex = 0; actionIndex < step.Actions.Length; actionIndex++)
			{
				result += $"[{step.Actions[actionIndex].Status}]" +
				          $"{actionIndex}. {step.Actions[actionIndex].Description}\n";
			}

			return result;
		}
	}
}