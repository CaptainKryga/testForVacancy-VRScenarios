namespace Project.Scripts.View.Sync.Abstract
{
	//Abstract class for sync components
	public abstract class SyncComponentAbstract<T> : ComponentIdAbstract
	{
		// Sync components MonoBehaviour
		public T Component { get; private set; }

		protected void Awake()
		{
			Component = GetComponent<T>();
		}
		
		// Method sync component
		public abstract void UpdateByComponentT(T component);
	}
}