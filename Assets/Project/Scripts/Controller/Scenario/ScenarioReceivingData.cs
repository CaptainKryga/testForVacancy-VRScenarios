using Project.Scripts.Model.ScenarioComponents;
using Project.Scripts.Model.ScriptableObjects.Scenario;

namespace Project.Scripts.Controller.Scenario
{
	public class ScenarioReceivingData
	{
		// Method decode scenaries from model app
		public Model.ScenarioComponents.Scenario ConvertScriptableToScripts(ScenarioScriptable scenarioScriptable)
		{
			Model.ScenarioComponents.Scenario scenario = new Model.ScenarioComponents.Scenario(
				scenarioScriptable.Title,
				scenarioScriptable.Description,
				new ScenarioGroup[scenarioScriptable.GroupSteps.Length]);

			ScenarioGroupScriptable[] groups = scenarioScriptable.GroupSteps;
			for (int i = 0; i < groups.Length; i++)
			{
				scenario.Groups[i] = new ScenarioGroup(
					groups[i].Title, 
					groups[i].Description, 
					new ScenarioStep[groups[i].Steps.Length]);
				
				ScenarioStepScriptable[] steps = groups[i].Steps;
				for (int i2 = 0; i2 < steps.Length; i2++)
				{
					scenario.Groups[i].Steps[i2] = new ScenarioStep(
						steps[i2].Title, 
						steps[i2].Description, 
						new ScenarioAction[steps[i2].Actions.Length]);
				
					ScenarioActionScriptable[] actions = steps[i2].Actions;
					for (int i3 = 0; i3 < actions.Length; i3++)
					{
						scenario.Groups[i].Steps[i2].Actions[i3] = new ScenarioAction(
							actions[i3].Description, actions[i3]);

					}
				}
			}
			
			return scenario;
		}
	}
}