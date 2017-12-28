using UnityEditor;
using UnityEngine;

namespace AssetsPattern
{
	[CustomPropertyDrawer(typeof(Vector2Reference))]
	public class Vector2ReferenceDrawer : GenericReferenceDrawer<Vector2>
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			base.OnGUI(position, property, label);
		}
	}
}
