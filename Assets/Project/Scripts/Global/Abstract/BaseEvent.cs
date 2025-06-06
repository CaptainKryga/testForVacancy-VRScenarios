using System;
using JetBrains.Annotations;

namespace Project.Scripts.Global.Abstract
{
	// Abstract event from manager
	public class BaseEvent<T>
	{
		public T EventName { get; set; }
		public Action<object> ListenerAction { get; set; }
		[CanBeNull]
		public Action CallerAction { get; set; }
	}
}