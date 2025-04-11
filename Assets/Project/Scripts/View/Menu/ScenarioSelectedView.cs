using Project.Scripts.Controller;
using Project.Scripts.Global.Managers;
using Project.Scripts.Model;
using Project.Scripts.View.Sync.Components;
using UnityEngine;

namespace Project.Scripts.View.Menu
{
	// View scenario selected controller component
	public class ScenarioSelectedView : MonoBehaviour
	{
		[SerializeField] private SyncButton _buttonLoadScene;

		// Enable button from load scene
		public void EnableButtonLoadScene()
		{
			_buttonLoadScene.ComponentSync.interactable = true;
			SyncManager.Instance.Push(SyncType.Button, _buttonLoadScene);
		}
	}
}