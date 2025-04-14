namespace Project.Scripts.Model.ScenarioComponents
{
	public class Scenario
	{
		public string Title { get; private set; }
		public string Description { get; private set; }
		public ScenarioGroup[] Groups { get; private set; }
		
		public ScenarioStatusEnum Status { get; set; }

		public Scenario(string title, string description, params ScenarioGroup[] groups)
		{
			Title = title;
			Description = description;
			Groups = groups;

			Status = ScenarioStatusEnum.NotStarted;
		}
	}
}