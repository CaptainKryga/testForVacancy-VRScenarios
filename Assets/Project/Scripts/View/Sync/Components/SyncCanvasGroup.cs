using Project.Scripts.Global.Managers;
using Project.Scripts.Model;
using Project.Scripts.View.Sync.Abstract;
using UnityEngine;

namespace Project.Scripts.View.Sync.Components
{
	// update view component GameObject
	public class SyncCanvasGroup : SyncComponentAbstract<CanvasGroup>
	{
		public override void UpdateComponentByT(CanvasGroup component)
		{
			ComponentSync.alpha = component.alpha;
		}

		public override void SyncAllComponentsByT()
		{
			SyncManager.Instance.Push(SyncType.CanvasGroup, this);
		}
	}
}