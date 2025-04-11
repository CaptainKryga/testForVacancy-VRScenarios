using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Scripts.Controller
{
	// Load scene control
	public class SceneLoadController : MonoBehaviour
	{
		#region Private Methods
		
		// Base method load scene from string name
		private void LoadScene(string sceneName)
		{
			SceneManager.LoadScene(sceneName);
		}
		
		#endregion
		
		#region Buttons

		// button load scene from main menu
		public void OnClick_LoadScene(string sceneName)
		{
			LoadScene(sceneName);
		}

		#endregion
	}
}