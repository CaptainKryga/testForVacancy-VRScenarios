namespace Project.Scripts.View.Component.Abstract
{
	// anybody monobehaviour unity component from get type T
	public abstract class ComponentTypeAbstract<T> : ComponentAbstract
	{
		protected T Component;
		
		private void Awake()
		{
			Component = GetComponent<T>();
		}
	}
}