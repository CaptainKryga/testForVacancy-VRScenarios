using Project.Scripts.Controller.SyncView.Abstract;
using Project.Scripts.Global.Managers;
using Project.Scripts.Model;
using Project.Scripts.View.Sync.Abstract;
using UnityEngine.UI;

namespace Project.Scripts.Controller.SyncView.Controllers
{
	// Controller Sync from component UI Button
	public class SyncButtonController : SyncControllerAbstract<Button>
	{
		private void OnEnable()
		{
			SyncManager.Instance.Listen(SyncType.Button, FuncSyncButton);
		}

		private void OnDisable()
		{
			SyncManager.Instance.UnListen(SyncType.Button, FuncSyncButton);
		}

		private void FuncSyncButton(object obj)
		{
			if (obj is SyncComponentAbstract<Button> btn)
				UpdateComponentsByT(btn);
		}
	}
}