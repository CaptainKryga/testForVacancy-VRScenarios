using Project.Scripts.View.Sync.Components;
using UnityEngine;

namespace Project.Scripts.View.TrainingRoom
{
	public class ScenarioListView : MonoBehaviour
	{
		// Link scenario list text
		[SerializeField] private SyncText _syncText;
		
		// Init scenario list
		public void ScenarioInit(string scenario)
		{
			_syncText.ComponentSync.text = scenario;
			_syncText.SyncAllComponentsByT();
		}
	}
}