using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.Global.Abstract
{
	public class Manager<T> : Singleton<Manager<T>>
	{
		private readonly Dictionary<T, List<BaseEvent<T>>> _eventDictionary = new Dictionary<T, List<BaseEvent<T>>>();

		public void Listen(T gameEvent, Action<object> listenerAction, Action callerAction = null)
		{
			var newUIEvent = new BaseEvent<T>
			{
				EventName = gameEvent,
				ListenerAction = listenerAction,
				CallerAction = callerAction
			};
			if (!_eventDictionary.ContainsKey(gameEvent))
			{
				var newBaseTimerList = new List<BaseEvent<T>>();
				_eventDictionary.Add(gameEvent, newBaseTimerList);
			}
			_eventDictionary[gameEvent].Add(newUIEvent);
		}
        
		public void UnListen(T gameEvent, Action<object> listenerAction, Action callerAction = null)
		{
			foreach (var @event in _eventDictionary[gameEvent])
			{
				if (@event.ListenerAction == listenerAction)
				{
					_eventDictionary[gameEvent].Remove(@event);
					break;
				}
			}
		}

		public void Push(T gameEvent, object obj = null)
		{
			if (!_eventDictionary.ContainsKey(gameEvent))
			{
				Debug.LogWarning(gameEvent + " check dict event's");
				return;
			}
			foreach (var @event in _eventDictionary[gameEvent])
			{
				@event.CallerAction?.Invoke();
				@event.ListenerAction(obj);
				// Debug.Log(@event.EventName);
			}
		}
	}
}