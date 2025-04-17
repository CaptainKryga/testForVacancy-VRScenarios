using Project.Scripts.Global.Managers;
using Project.Scripts.Model;
using Project.Scripts.Model.ScriptableObjects.Scenario;
using UnityEngine;

namespace Project.Scripts.Controller.Scenario
{
    public class ScenarioTrigger : MonoBehaviour
    {
        [SerializeField] private ScenarioActionScriptable actionScript;
        
        // Trigger from task manager on complete task
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
                ScenarioManager.Instance.Push(ScenarioType.Action, actionScript);
        }
    }
}
