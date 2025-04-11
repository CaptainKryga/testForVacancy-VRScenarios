using Project.Scripts.View.Sync.Abstract;
using TMPro;
using UnityEngine;

namespace Project.Scripts.View.Sync.Components
{
	[RequireComponent(typeof(TMP_Text))]
	// component TMP_Text
	public class SyncComponentText : SyncComponentAbstract<TMP_Text>
	{
		public override void UpdateByComponentT(TMP_Text component)
		{
			Component.text = component.text;
		}
	}
}