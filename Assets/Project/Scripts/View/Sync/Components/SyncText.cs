using Project.Scripts.Controller.SyncView;
using Project.Scripts.Global.Managers;
using Project.Scripts.Model;
using Project.Scripts.View.Sync.Abstract;
using TMPro;
using UnityEngine;

namespace Project.Scripts.View.Sync.Components
{
	[RequireComponent(typeof(TMP_Text))]
	// component TMP_Text
	public class SyncText : SyncComponentAbstract<TMP_Text>
	{
		public override void UpdateByComponentT(TMP_Text component)
		{
			ComponentSync.text = component.text;
		}

		protected override void UpdateByAction()
		{
			SyncManager.Instance.Push(SyncType.Text, this);
		}
	}
}