namespace Project.Scripts.Model.ScenarioComponents
{
	// Step from group
	public class ScenarioStep
	{
		public string Title { get; private set; }
		public string Description { get; private set; }
		public ScenarioAction[] Actions { get; private set; }

		public ScenarioStatusEnum Status { get; set; }
		
		public ScenarioStep(string title, string description, params ScenarioAction[] actions)
		{
			Title = title;
			Description = description;
			Actions = actions;
			Status = ScenarioStatusEnum.NotStarted;
		}
	}
}