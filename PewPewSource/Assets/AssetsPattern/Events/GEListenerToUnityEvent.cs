using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AssetsPattern
{
	public class GEListenerToUnityEvent : GameEventListener
	{
		public UnityEvent EventToRaise;
		public override void OnEventRaised()
		{
			if (EventToRaise != null)
				EventToRaise.Invoke();
		}
	}
}