using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AssetsPattern
{
	public class GEListenerToTextField : GameEventListener
	{
		public IntReference Value;
		public UnityEngine.UI.Text TextField;

		public override void OnEventRaised()
		{
			TextField.text = Value.Value.ToString();
		}
	}
}
