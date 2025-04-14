using UnityEngine;

namespace Project.Scripts.Model.ScriptableObjects.Scenario
{
    [CreateAssetMenu(fileName = "ScenarioActionScriptable", 
        menuName = "ScriptableObjects/Scenario/ScenarioActionScriptable", order = 4)]
    // Link actions from step and scenario manager logic
    public class ScenarioActionScriptable : ScriptableObject
    {
        public string Description;
    }
}
