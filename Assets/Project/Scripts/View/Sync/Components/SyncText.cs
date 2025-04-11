using Project.Scripts.View.Sync.Abstract;
using TMPro;
using UnityEngine;

namespace Project.Scripts.View.Sync.Components
{
	[RequireComponent(typeof(TMP_Text))]
	// update view component TMP_Text
	public class SyncText : SyncComponentAbstract<TMP_Text>
	{
		public override void UpdateComponentByT(TMP_Text component)
		{
			ComponentSync.text = component.text;
		}
	}
}