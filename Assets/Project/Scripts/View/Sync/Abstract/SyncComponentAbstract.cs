using Project.Scripts.View.Component.Abstract;
using UnityEngine;

namespace Project.Scripts.View.Sync.Abstract
{
	[RequireComponent(typeof(ComponentAbstract))]
	//Abstract class for sync components
	public abstract class SyncComponentAbstract<T> : ComponentIdAbstract
	{
		// View update component
		protected ComponentAbstract ComponentView;
		
		// Sync components MonoBehaviour
		public T ComponentSync { get; private set; }

		protected void Awake()
		{
			ComponentSync = GetComponent<T>();
			ComponentView = GetComponent<ComponentAbstract>();

			ComponentView.UpdateAction += UpdateByAction;
		}
		
		// Method sync component
		public abstract void UpdateByComponentT(T component);

		protected abstract void UpdateByAction();
	}
}