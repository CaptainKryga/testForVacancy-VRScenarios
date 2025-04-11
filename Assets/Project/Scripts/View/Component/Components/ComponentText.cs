using Project.Scripts.View.Component.Abstract;
using TMPro;
using UnityEngine;

namespace Project.Scripts.View.Component.Components
{
	[RequireComponent(typeof(TMP_Text))]
	// view component text
	public class ComponentText : ComponentTypeAbstract<TMP_Text>
	{
		public override void Activate()
		{
			base.Activate();
		}
	}
}
