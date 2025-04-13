using Project.Scripts.Controller.SyncView.Abstract;
using Project.Scripts.Global.Managers;
using Project.Scripts.Model;
using Project.Scripts.View.Sync.Abstract;
using Project.Scripts.View.Sync.Components;
using TMPro;

namespace Project.Scripts.Controller.SyncView.Controllers
{
	// Controller Sync from component UI TMP_Text
	public class SyncTextController : SyncControllerAbstract<TMP_Text>
	{
		private void OnEnable()
		{
			SyncManager.Instance.Listen(SyncType.Text, FuncSyncText);
		}

		private void OnDisable()
		{
			SyncManager.Instance.UnListen(SyncType.Text, FuncSyncText);
		}

		private void FuncSyncText(object obj)
		{
			if (obj is SyncText text)
				UpdateComponentsByT(text);
		}
	}
}