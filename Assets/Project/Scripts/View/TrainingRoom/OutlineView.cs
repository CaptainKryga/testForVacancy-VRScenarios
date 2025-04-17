using Project.Scripts.Model.ScriptableObjects.Scenario;
using UnityEngine;

namespace Project.Scripts.View.TrainingRoom
{
    [RequireComponent(typeof(Outline))]
    // View set visible outline
    public class OutlineView : MonoBehaviour
    {
        [SerializeField] private ScenarioActionScriptable _link;
        private Outline _outline;
        private void Awake()
        {
            _outline = GetComponent<Outline>();
        }

        public void UpdateOutline(ScenarioActionScriptable link)
        {
            _outline.enabled = link == _link;
        }
    }
}
