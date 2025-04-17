namespace Project.Scripts.Model.ScenarioComponents
{
	// Group from scenarios
	public class ScenarioGroup
	{
		public string Title { get; private set; }
		public string Description { get; private set; }
		public ScenarioStep[] Steps { get; private set; }

		public ScenarioStatusEnum Status { get; set; }

		public ScenarioGroup(string title, string description, params ScenarioStep[] steps)
		{
			Title = title;
			Description = description;
			Steps = steps;
			
			Status = ScenarioStatusEnum.NotStarted;
		}
	}
}