using UnityEngine;
using UnityEditor;

namespace AssetsPattern.Editor
{
	[CustomPropertyDrawer(typeof(GameEvent))]
	public class GameEventPropertyDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			label = EditorGUI.BeginProperty(position, label, property);
			position = EditorGUI.PrefixLabel(position, label);

			var indent = EditorGUI.indentLevel;
			EditorGUI.indentLevel = 0;
			EditorGUI.BeginChangeCheck();

			var target = property.objectReferenceValue as GameEvent;
			if (Application.isPlaying && target != null)
			{
				const float widthButton = 80f;
				var heightButton = position.height;
				var rectButton = new Rect(position.x, position.y, widthButton, heightButton);
				position.width -= widthButton;
				position.x += widthButton;
				if (GUI.Button(rectButton, "Raise"))
					target.Raise();
			}

			EditorGUI.PropertyField(position, property, GUIContent.none);

			if (EditorGUI.EndChangeCheck())
				property.serializedObject.ApplyModifiedProperties();

			EditorGUI.indentLevel = indent;
			EditorGUI.EndProperty();
		}
	}
}
