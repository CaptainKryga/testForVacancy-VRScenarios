namespace Project.Scripts.View.Sync.Abstract
{
	//Abstract class for sync components
	public abstract class SyncComponentAbstract<T> : ComponentIdAbstract
	{
		// Sync components MonoBehaviour
		public T ComponentSync { get; private set; }

		protected void Awake()
		{
			ComponentSync = GetComponent<T>();
		}
		
		// Method sync component
		public abstract void UpdateComponentByT(T component);
	}
}