using Project.Scripts.Controller.SyncView;
using Project.Scripts.Global.Managers;
using Project.Scripts.Model;
using Project.Scripts.View.Component.Abstract;
using Project.Scripts.View.Sync.Abstract;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.View.Sync.Components
{
	[RequireComponent(typeof(Button))]	
	[RequireComponent(typeof(ComponentAbstract))]	
	// component Button
	public class SyncButton : SyncComponentAbstract<Button>
	{
		public override void UpdateByComponentT(Button component)
		{
			ComponentSync.interactable = component.interactable;
		}

		protected override void UpdateByAction()
		{
			SyncManager.Instance.Push(SyncType.Button, this);
		}
	}
}