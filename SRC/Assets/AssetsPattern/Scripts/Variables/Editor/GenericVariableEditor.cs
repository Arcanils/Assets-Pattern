using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace AssetsPattern
{
	public abstract class GenericVariableEditor<T, S> : Editor where T : GenericVariable<S>
	{
		/*
		private SerializedProperty _valueProp;
		
		private void OnEnable()
		{
			_valueProp = serializedObject.FindProperty("_value");
		}*/
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			GUI.enabled = Application.isPlaying;

			var currentTarget = target as GenericVariable<S>;
			/*
			if (EditorGUILayout.PropertyField(_valueProp))
			{
				currentTarget.OnChangeValue();
			}*/

			if (GUILayout.Button("RaiseEvent : OnChangeValue"))
			{
				currentTarget.OnChangeValue();
			}
		}
	}

}