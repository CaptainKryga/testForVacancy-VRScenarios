using UnityEngine;

namespace Project.Scripts.Global.Abstract
{
	// Singleton logic from Manager Type
	public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
	{
		private static T _instance;
		public static T Instance => _instance;

		protected virtual void Awake()
		{
			if (Instance == null)
				_instance = GetComponent<T>();
			else
				Debug.LogError("Check Instance create " + typeof(T));
		}
	}
}