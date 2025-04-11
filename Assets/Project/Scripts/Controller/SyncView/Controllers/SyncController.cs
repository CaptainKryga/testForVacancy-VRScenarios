using Project.Scripts.Controller.SyncView.Abstract;
using Project.Scripts.View.Sync.Components;
using TMPro;

namespace Project.Scripts.Controller.SyncView.Controllers
{
	// controller sync from scene
	public class SyncController : ControllerBaseAbstract
	{
		#region Variables
		
		private SyncViewControllerAbstract<TMP_Text> _syncTextController;
		
		#endregion
		
		#region Initialization
		// Init sync controller's
		public override void Init()
		{
			_syncTextController = new SyncViewTextController();
			_syncTextController.Init();
		}
		
		#endregion

		#region Public Methods
		
		// Public sync action
		public void OnAction_SyncTextComponents(SyncComponentText component)
		{
			_syncTextController.UpdateComponentsByT(component);
		}
		
		#endregion
	}
}