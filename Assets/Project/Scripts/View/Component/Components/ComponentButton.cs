using Project.Scripts.View.Component.Abstract;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.View.Component.Components
{
	[RequireComponent(typeof(Button))]
	// component button
	public class ComponentButton : ComponentTypeAbstract<Button>
	{
		public override void Activate()
		{
			Component.interactable = true;
		}
	}
}
