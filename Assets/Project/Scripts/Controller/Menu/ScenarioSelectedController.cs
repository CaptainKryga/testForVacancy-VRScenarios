using Project.Scripts.Controller.Scenario;
using Project.Scripts.Model;
using Project.Scripts.Model.ScriptableObjects;
using Project.Scripts.Model.ScriptableObjects.Scenario;
using Project.Scripts.View.Menu;
using UnityEngine;

namespace Project.Scripts.Controller.Menu
{
    // Controller selected scenario from training room and convert
    public class ScenarioSelectedController : MonoBehaviour
    {
        // View selected
        [SerializeField] private ScenarioSelectedView _scenarioSelectedView;
        
        // Converted scriptable to script
        private readonly ScenarioReceivingData _scenarioReceivingData = new ScenarioReceivingData();
        
        public void OnClick_ScenarioSelected(ScenarioScriptable scenario)
        {
            // ScenarioModel.ScenarioScriptable = scenario;
            ScenarioModel.Scenario = _scenarioReceivingData.ConvertScriptableToScripts(scenario);
            
            // activate button load scene
            _scenarioSelectedView.EnableButtonLoadScene();
        }
    }
}
