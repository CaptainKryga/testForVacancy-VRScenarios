using UnityEngine;

namespace Project.Scripts.Controller.Menu
{
	// main controller from menu
	public class MainMenuController : MonoBehaviour
	{
		[SerializeField] private ControllerBaseAbstract _syncController;
		
		private void Start()
		{
			// Init sync view logic
			_syncController.Init();
		}
	}
}