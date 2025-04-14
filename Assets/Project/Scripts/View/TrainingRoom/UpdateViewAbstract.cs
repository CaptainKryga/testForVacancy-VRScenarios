using UnityEngine;

namespace Project.Scripts.View.TrainingRoom
{
	public abstract class UpdateViewAbstract<T> : MonoBehaviour
	{
		public abstract void UpdateComponent(T value);
	}
}