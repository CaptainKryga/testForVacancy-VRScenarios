using Project.Scripts.Global.Managers;
using Project.Scripts.Model;
using Project.Scripts.Model.ScriptableObjects.Scenario;
using UnityEngine;

namespace Project.Scripts.Controller.Scenario
{
    public class ScenarioTrigger : MonoBehaviour
    {
        [SerializeField] private ScenarioActionScriptable actionScript;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
                ScenarioManager.Instance.Push(ScenarioType.Action, actionScript);
        }
    }
}
