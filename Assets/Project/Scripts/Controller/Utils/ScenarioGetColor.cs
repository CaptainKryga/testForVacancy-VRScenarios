using Project.Scripts.Model.ScenarioComponents;

namespace Project.Scripts.Controller.Utils
{
	// Getting color
	public class ScenarioGetColor
	{
		// Getting color depending on task status
		public string GetColorByStatus(ScenarioStatusEnum status)
		{
			switch (status)
			{
				case ScenarioStatusEnum.NotStarted: return "black";
				case ScenarioStatusEnum.Started: return "white";
				case ScenarioStatusEnum.Success: return "green";
				case ScenarioStatusEnum.Failure: return "red";
				case ScenarioStatusEnum.Skipped: return "grey";
				default: return "black";
			}
		}
	}
}