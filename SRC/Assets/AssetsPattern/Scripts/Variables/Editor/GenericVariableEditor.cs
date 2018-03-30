using UnityEngine;

namespace AssetsPattern.Editor
{
	public abstract class GenericVariableEditor<TType> : UnityEditor.Editor
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			GUI.enabled = Application.isPlaying;

			var currentTarget = target as GenericVariable<TType>;
			if (currentTarget == null)
				return;

			if (GUILayout.Button("RaiseEvent : OnChangeValue"))
			{
				currentTarget.OnChangeValue();
			}
		}
	}

}