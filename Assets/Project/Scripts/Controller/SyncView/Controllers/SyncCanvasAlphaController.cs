using Project.Scripts.Controller.SyncView.Abstract;
using Project.Scripts.Global.Managers;
using Project.Scripts.Model;
using Project.Scripts.View.Sync.Abstract;
using UnityEngine;

namespace Project.Scripts.Controller.SyncView.Controllers
{
    public class SyncCanvasAlphaController : SyncControllerAbstract<CanvasGroup>
    {
        private void OnEnable()
        {
            SyncManager.Instance.Listen(SyncType.CanvasGroup, FuncSyncCanvasGroup);
        }

        private void OnDisable()
        {
            SyncManager.Instance.UnListen(SyncType.CanvasGroup, FuncSyncCanvasGroup);
        }

        private void FuncSyncCanvasGroup(object obj)
        {
            if (obj is SyncComponentAbstract<CanvasGroup> canvasGroup)
                UpdateComponentsByT(canvasGroup);
        }
    }
}
