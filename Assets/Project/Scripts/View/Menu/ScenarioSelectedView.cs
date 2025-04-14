using Project.Scripts.View.Sync.Abstract;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.View.Menu
{
	// View scenario selected controller component
	public class ScenarioSelectedView : MonoBehaviour
	{
		[SerializeField] private SyncComponentAbstract<Button> _buttonLoadScene;

		// Enable button from load scene
		public void EnableButtonLoadScene()
		{
			_buttonLoadScene.ComponentSync.interactable = true;
			_buttonLoadScene.SyncAllComponentsByT();
		}
	}
}