using Project.Scripts.Global.Managers;
using Project.Scripts.Model;
using Project.Scripts.View.Sync.Abstract;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.View.Sync.Components
{
	[RequireComponent(typeof(Button))]	
	// update view component Button
	public class SyncButton : SyncComponentAbstract<Button>
	{
		public override void UpdateComponentByT(Button component)
		{
			ComponentSync.interactable = component.interactable;
		}

		public override void SyncAllComponentsByT()
		{
			SyncManager.Instance.Push(SyncType.Button, this);
		}
	}
}