using System;
using Project.Scripts.View.Sync.Components;
using UnityEngine;

namespace Project.Scripts.View.TrainingRoom
{
    // Enable final window
    public class UpdateTrainingEndView : UpdateViewAbstract<string>
    {
        [SerializeField] private SyncCanvasGroup _trainingEndView;
        [SerializeField] private SyncText _trainingEndTextView;
        [SerializeField] private SyncCanvasGroup _subUIView;

        private void Start()
        {
            _trainingEndView.ComponentSync.alpha = 0;
            _trainingEndView.ComponentSync.interactable = false;
            _trainingEndView.ComponentSync.blocksRaycasts = false;
            _trainingEndView.SyncAllComponentsByT();
        }

        public override void UpdateComponent(string value)
        {
            _trainingEndView.ComponentSync.alpha = 1;
            _trainingEndView.ComponentSync.interactable = true;
            _trainingEndView.ComponentSync.blocksRaycasts = true;
            _trainingEndView.SyncAllComponentsByT();

            _subUIView.ComponentSync.alpha = 0;
            _subUIView.SyncAllComponentsByT();

            _trainingEndTextView.ComponentSync.text = value;
            _trainingEndTextView.SyncAllComponentsByT();
        }
    }
}
