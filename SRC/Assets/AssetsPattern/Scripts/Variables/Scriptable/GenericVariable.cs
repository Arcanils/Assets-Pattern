using UnityEngine;

namespace AssetsPattern
{
	[System.Serializable]
	public class GenericVariable<TType> : ScriptableObject
	{
#if UNITY_EDITOR
		[Multiline]
		public string DeveloperDescription = "";
#endif
		public TType Value
		{
			get
			{
				return _value;
			}
			set
			{
				if (_value.Equals(value)) return;
				_value = value;
				OnChangeValue();
			}
		}
		[SerializeField]
		private TType _value;

		private System.Action _onValueChange;
		

		public void SetValue(GenericVariable<TType> value)
		{
			Value = value.Value;
		}

		public void AddListernerToOnValueChange(System.Action callback)
		{
			_onValueChange += callback;
		}

		public void RemoveListernerToOnValueChange(System.Action callback)
		{
			_onValueChange -= callback;
		}

		public void OnChangeValue()
		{
			if (_onValueChange != null)
			{
				_onValueChange();
			}
		}
	}
}
