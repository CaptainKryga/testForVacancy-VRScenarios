using Project.Scripts.Controller.SyncView.Abstract;
using Project.Scripts.Controller.SyncView.Controllers;
using Project.Scripts.Global.Managers;
using Project.Scripts.Model;
using Project.Scripts.View.Sync.Abstract;
using Project.Scripts.View.Sync.Components;
using TMPro;
using UnityEngine.UI;

namespace Project.Scripts.Controller
{
	// controller sync from scene
	public class SyncGlobalController : ControllerBaseAbstract
	{
		#region Variables
		
		private SyncControllerAbstract<TMP_Text> _syncTextController;
		private SyncControllerAbstract<Button> _syncButtonController;
		
		#endregion
		
		#region Manager logic

		private void OnEnable()
		{
			SyncManager.Instance.Listen(SyncType.Text, FuncSyncText);
			SyncManager.Instance.Listen(SyncType.Button, FuncSyncButton);
		}

		private void OnDisable()
		{
			SyncManager.Instance.UnListen(SyncType.Text, FuncSyncText);
			SyncManager.Instance.UnListen(SyncType.Button, FuncSyncButton);
		}

		private void FuncSyncText(object obj)
		{
			if (obj is SyncText text)
				_syncTextController.UpdateComponentsByT(text);
		}
		
		private void FuncSyncButton(object obj)
		{
			if (obj is SyncComponentAbstract<Button> btn)
				_syncButtonController.UpdateComponentsByT(btn);
		}
		
		#endregion
		
		#region Init
		
		// Init sync controller's
		public override void Init()
		{
			_syncTextController = new SyncTextController();
			_syncTextController.Init();
			
			_syncButtonController = new SyncButtonController();
			_syncButtonController.Init();
		}
		
		#endregion
	}
}