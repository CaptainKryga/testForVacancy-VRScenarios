using UnityEngine;

namespace Project.Scripts.Controller
{
	// Base script from custom not abstract controller and initialization from the main controller is needed
	public abstract class ControllerBaseAbstract : MonoBehaviour
	{
		public abstract void Init();
	}
}