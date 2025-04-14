using Project.Scripts.View.Sync.Components;
using UnityEngine;

namespace Project.Scripts.View.TrainingRoom
{
    public class UpdateTrainingEndView : UpdateViewAbstract<string>
    {
        [SerializeField] private SyncCanvasGroup _trainingEndView;
        [SerializeField] private SyncText _trainingEndTextView;
        
        public override void UpdateComponent(string value)
        {
            _trainingEndView.ComponentSync.alpha = 1;
            _trainingEndView.SyncAllComponentsByT();
            
            _trainingEndTextView.ComponentSync.text = value;
            _trainingEndTextView.SyncAllComponentsByT();
        }
    }
}
