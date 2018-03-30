using UnityEngine;
using UnityEngine.UI;

namespace AssetsPattern
{
	public class UIStringVariable : MonoBehaviour
	{
		public InputField UiInput;
		public Text UiText;
		public StringVariable VarToUpdate;

		public bool UpdateTextFromScriptable;
		public bool UpdateScriptableFromText;

		private void Reset()
		{
			UpdateTextFromScriptable = true;
			UpdateScriptableFromText = true;
		}

		private void OnEnable()
		{
			if (VarToUpdate != null && UpdateTextFromScriptable)
				VarToUpdate.AddListernerToOnValueChange(UpdateUiTarget);
			if (UiInput != null && UpdateScriptableFromText)
				UiInput.onValueChanged.AddListener(UpdateVariable);

			if (UpdateTextFromScriptable)
				UpdateUiTarget();
		}
		private void OnDisable()
		{
			if (VarToUpdate != null && UpdateTextFromScriptable)
				VarToUpdate.RemoveListernerToOnValueChange(UpdateUiTarget);
			if (UiInput != null && UpdateScriptableFromText)
				UiInput.onValueChanged.RemoveListener(UpdateVariable);
		}


		private void UpdateVariable(string newStr)
		{
			if (VarToUpdate == null || VarToUpdate.Value == newStr)
				return;

			VarToUpdate.Value = newStr;
		}


		private void UpdateUiTarget()
		{
			if (VarToUpdate == null)
				return;

			if (UiText != null && UiText.text != VarToUpdate.Value)
				UiText.text = VarToUpdate.Value;
			if (UiInput != null && UiInput.text != VarToUpdate.Value)
				UiInput.text = VarToUpdate.Value;
		}
	}
}
