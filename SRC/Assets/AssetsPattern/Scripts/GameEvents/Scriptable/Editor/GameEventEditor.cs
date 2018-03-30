using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace AssetsPattern.Editor
{
    [CustomEditor(typeof(GameEvent))]
    public class GameEventEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            var targetEvent = target as GameEvent;
	        if (targetEvent == null)
		        return;

            if (GUILayout.Button("Raise"))
                targetEvent.Raise();

			DisplayListEvents(targetEvent);
		}


		private static void DisplayListEvents(GameEvent target)
		{
			List<string> listAction;
			List<string> listGel;

			target.GetEvents(out listAction, out listGel);

			EditorGUILayout.LabelField("List event script", EditorStyles.boldLabel);
			EditorGUILayout.Space();
			foreach (var t in listAction)
			{
				EditorGUILayout.LabelField(t);
			}
			EditorGUILayout.LabelField("List event UI", EditorStyles.boldLabel);
			EditorGUILayout.Space();
			foreach (var t in listGel)
			{
				EditorGUILayout.LabelField(t);
			}
		}
    }
}