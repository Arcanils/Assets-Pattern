using UnityEngine;
using UnityEditor;

namespace AssetsPattern.Editor
{
	[CustomPropertyDrawer(typeof(StringGameEventPair))]
	public class StringGameEventPairEditor : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			label = EditorGUI.BeginProperty(position, label, property);
			position = EditorGUI.PrefixLabel(position, label);

			EditorGUI.BeginChangeCheck();

			// Get properties
			var propKey = property.FindPropertyRelative("Key");
			var propValue = property.FindPropertyRelative("Value");

			// Calculate rect for configuration button

			// Store old indent level and set it to 0, the PrefixLabel takes care of it
			var indent = EditorGUI.indentLevel;
			EditorGUI.indentLevel = 0;
			var rectKey = new Rect(position);
			rectKey.width /= 2f;
			var rectValue = new Rect(position);
			rectValue.x += rectKey.width;
			rectValue.width = position.width - rectKey.width;

			EditorGUI.PropertyField(rectKey, propKey, GUIContent.none);
			EditorGUI.PropertyField(rectValue, propValue, GUIContent.none);

			if (EditorGUI.EndChangeCheck())
				property.serializedObject.ApplyModifiedProperties();

			EditorGUI.indentLevel = indent;
			EditorGUI.EndProperty();
		}
	}

}
