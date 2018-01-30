using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace AssetsPattern
{
    [CustomEditor(typeof(GameEvent))]
    public class GameEventEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            GameEvent e = target as GameEvent;
            if (GUILayout.Button("Raise"))
                e.Raise();

			DisplayListEvents(e);
		}


		public void DisplayListEvents(GameEvent Target)
		{
			List<string> ListAction;
			List<string> ListGEL;

			Target.GetEvents(out ListAction, out ListGEL);

			EditorGUILayout.LabelField("List event script", EditorStyles.boldLabel);
			EditorGUILayout.Space();
			for (int i = 0; i < ListAction.Count; i++)
			{
				EditorGUILayout.LabelField(ListAction[i]);
			}
			EditorGUILayout.LabelField("List event UI", EditorStyles.boldLabel);
			EditorGUILayout.Space();
			for (int i = 0; i < ListGEL.Count; i++)
			{
				EditorGUILayout.LabelField(ListGEL[i]);
			}
		}
    }
}