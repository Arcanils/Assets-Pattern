using UnityEditor;

namespace AssetsPattern.Editor
{
    [CustomEditor(typeof(UIButtonGameEvent))]
    public class UIButtonGameEventEditor : UnityEditor.UI.ButtonEditor
	{
		private SerializedProperty _propEventsToRaise;

		protected override void OnEnable()
		{
			base.OnEnable();

			_propEventsToRaise = serializedObject.FindProperty("EventsToRaise");
		}
		public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

			EditorGUILayout.PropertyField(_propEventsToRaise, true);
		}
    }
}