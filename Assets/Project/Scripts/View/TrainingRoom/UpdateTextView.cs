using Project.Scripts.View.Sync.Abstract;
using TMPro;
using UnityEngine;

namespace Project.Scripts.View.TrainingRoom
{
	public class UpdateTextView : UpdateViewAbstract<string>
	{
		// Link text
		[SerializeField] private SyncComponentAbstract<TMP_Text> _syncText;

		// Update sync text
		public override void UpdateComponent(string value)
		{
			_syncText.ComponentSync.text = value;
			_syncText.SyncAllComponentsByT();
		}
	}
}