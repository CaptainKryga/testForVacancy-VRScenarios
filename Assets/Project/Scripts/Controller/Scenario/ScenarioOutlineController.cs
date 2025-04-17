using Project.Scripts.Model.ScriptableObjects.Scenario;
using Project.Scripts.View.TrainingRoom;
using UnityEngine;

namespace Project.Scripts.Controller.Scenario
{
	public class ScenarioOutlineController : MonoBehaviour
	{
		private OutlineView[] _outlines;
		private void Awake()
		{
			_outlines = FindObjectsOfType<OutlineView>();
		}

		public void UpdateOutlines(ScenarioActionScriptable link)
		{
			for (int i = 0; i < _outlines.Length; i++)
			{
				_outlines[i].UpdateOutline(link);
			}
		}
	}
}
