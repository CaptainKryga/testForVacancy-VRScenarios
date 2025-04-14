using Project.Scripts.Controller.Utils;
using Project.Scripts.Model.ScenarioComponents;

namespace Project.Scripts.Controller.Scenario
{
	public class ScenarioConvertModelToText
	{
		private readonly StringChange _stringChange = new();
		private readonly ScenarioGetColor _scenarioGetColor = new();

		public string GetScenarioText(Model.ScenarioComponents.Scenario scenario)
		{
			string result = $"{scenario.Title}[{scenario.Description}]\n";
			ScenarioGroup[] groupSteps = scenario.Groups;
			for (int groupIndex = 0; groupIndex < groupSteps.Length; groupIndex++)
			{
				result += _stringChange.SetColorFromString($"{groupIndex}. {groupSteps[groupIndex].Title}[{groupSteps[groupIndex].Description}]",
					_scenarioGetColor.GetColorByStatus(groupSteps[groupIndex].Status)) + "\n";
				for (int stepIndex = 0; stepIndex < groupSteps[groupIndex].Steps.Length; stepIndex++)
				{
					result += _stringChange.SetColorFromString($"  {stepIndex}) {groupSteps[groupIndex].Steps[stepIndex].Title}[{groupSteps[groupIndex].Steps[stepIndex].Description}]",
					_scenarioGetColor.GetColorByStatus(groupSteps[groupIndex].Status)) + "\n";
					for (int actionIndex = 0; actionIndex < groupSteps[groupIndex].Steps[stepIndex].Actions.Length; actionIndex++)
					{
						result += _stringChange.SetColorFromString($"\t{actionIndex}) {groupSteps[groupIndex].Steps[stepIndex].Actions[actionIndex].Description}",
						_scenarioGetColor.GetColorByStatus(groupSteps[groupIndex].Status)) + "\n";
					}
				}
			}

			return result;
		}
	}
}