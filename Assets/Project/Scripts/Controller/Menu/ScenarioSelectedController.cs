using Project.Scripts.Model;
using Project.Scripts.Model.ScriptableObjects;
using Project.Scripts.View.Menu;
using UnityEngine;

namespace Project.Scripts.Controller.Menu
{
    // controller selected scenario from training room
    public class ScenarioSelectedController : MonoBehaviour
    {
        [SerializeField] private ScenarioSelectedView _scenarioSelectedView;
        
        public void OnClick_ScenarioSelected(ScenarioScriptable scenario)
        {
            ScenarioModel.ScenarioScriptable = scenario;
            
            // activate button load scene
            _scenarioSelectedView.EnableButtonLoadScene();
        }
    }
}
