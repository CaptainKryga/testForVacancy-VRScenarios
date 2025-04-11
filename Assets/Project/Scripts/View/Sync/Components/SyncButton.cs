using Project.Scripts.View.Sync.Abstract;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.View.Sync.Components
{
	[RequireComponent(typeof(Button))]	
	// component Button
	public class SyncButton : SyncComponentAbstract<Button>
	{
		public override void UpdateComponentByT(Button component)
		{
			ComponentSync.interactable = component.interactable;
		}
	}
}