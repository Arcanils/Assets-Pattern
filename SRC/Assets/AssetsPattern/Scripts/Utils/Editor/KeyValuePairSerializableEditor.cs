using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(StringGameEventPair))]
public class KeyValuePairSerializableEditor : PropertyDrawer
{
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		label = EditorGUI.BeginProperty(position, label, property);
		position = EditorGUI.PrefixLabel(position, label);

		EditorGUI.BeginChangeCheck();

		// Get properties
		SerializedProperty propKey = property.FindPropertyRelative("Key");
		SerializedProperty propValue = property.FindPropertyRelative("Value");

		// Calculate rect for configuration button

		// Store old indent level and set it to 0, the PrefixLabel takes care of it
		int indent = EditorGUI.indentLevel;
		EditorGUI.indentLevel = 0;
		Rect rectKey = new Rect(position);
		rectKey.width /= 2f;
		Rect rectValue = new Rect(position);
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
