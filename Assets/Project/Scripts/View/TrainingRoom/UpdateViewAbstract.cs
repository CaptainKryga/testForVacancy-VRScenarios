using UnityEngine;

namespace Project.Scripts.View.TrainingRoom
{
	// Set abstract T value
	public abstract class UpdateViewAbstract<T> : MonoBehaviour
	{
		public abstract void UpdateComponent(T value);
	}
}