using UnityEditor;
using UnityEngine;

namespace AssetsPattern
{
    [CustomPropertyDrawer(typeof(FloatReference))]
    public class FloatReferenceDrawer : GenericReferenceDrawer<float>
    {
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			base.OnGUI(position, property, label);
		}
	}
}