using UnityEditor;
using UnityEngine;

namespace AssetsPattern
{
	[CustomPropertyDrawer(typeof(IntReference))]
	public class IntReferenceDrawer : GenericReferenceDrawer<int>
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			base.OnGUI(position, property, label);
		}
	}
}
