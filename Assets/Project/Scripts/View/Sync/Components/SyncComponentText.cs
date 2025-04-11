using Project.Scripts.View.Sync.Abstract;
using TMPro;

namespace Project.Scripts.View.Sync.Components
{
	public class SyncComponentText : SyncComponentAbstract<TMP_Text>
	{
		public override void UpdateByComponentT(TMP_Text component)
		{
			Component.text = component.text;
		}
	}
}