using UnityEditor;

namespace AssetsPattern
{
    [CustomEditor(typeof(GE_Button))]
    public class GE_ButtonEditor : UnityEditor.UI.ButtonEditor
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
            //GE_Button e = target as GE_Button;

			EditorGUILayout.PropertyField(_propEventsToRaise, true);
		}
    }
}