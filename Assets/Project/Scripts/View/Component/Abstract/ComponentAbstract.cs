using System;
using UnityEngine;

namespace Project.Scripts.View.Component.Abstract
{
	// anybody monobehaviour unity component from activate
	public abstract class ComponentAbstract : MonoBehaviour
	{
		public Action UpdateAction;
		
		public virtual void Activate()
		{
			UpdateAction?.Invoke();
		}
	}
}
