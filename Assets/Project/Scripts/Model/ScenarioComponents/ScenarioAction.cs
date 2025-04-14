namespace Project.Scripts.Model.ScenarioComponents
{
	public class ScenarioAction
	{
		public string Description { get; private set; }
		
		public ScenarioStatusEnum Status { get; set; }

		public ScenarioAction(string description)
		{
			Description = description;
			
			Status = ScenarioStatusEnum.NotStarted;
		}
	}
}