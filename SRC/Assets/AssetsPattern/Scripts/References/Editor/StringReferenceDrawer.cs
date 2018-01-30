using UnityEditor;
using UnityEngine;

namespace AssetsPattern
{
	[CustomPropertyDrawer(typeof(Vector2Reference))]
	public class StringReferenceDrawer : GenericReferenceDrawer<string>
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			base.OnGUI(position, property, label);
		}
	}
}
