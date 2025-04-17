using Project.Scripts.Model.ScriptableObjects.Scenario;

namespace Project.Scripts.Model.ScenarioComponents
{
	// Link actions from step and scenario manager logic
	public class ScenarioAction
	{
		public string Description { get; private set; }
		
		public ScenarioActionScriptable Link { get; private set; }
		
		public ScenarioStatusEnum Status { get; set; }

		public ScenarioAction(string description, ScenarioActionScriptable link)
		{
			Description = description;
			Link = link;
			
			Status = ScenarioStatusEnum.NotStarted;
		}
	}
}