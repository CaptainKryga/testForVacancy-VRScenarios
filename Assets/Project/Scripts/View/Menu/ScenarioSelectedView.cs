using Project.Scripts.View.Component.Abstract;
using UnityEngine;

namespace Project.Scripts.View.Menu
{
	// View scenario selected controller component
	public class ScenarioSelectedView : MonoBehaviour
	{
		[SerializeField] private ComponentAbstract _buttonLoadScene;

		// Enable button from load scene
		public void EnableButtonLoadScene()
		{
			_buttonLoadScene.Activate();
		}
	}
}