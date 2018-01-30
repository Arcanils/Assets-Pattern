using UnityEngine;

namespace AssetsPattern
{
	[System.Serializable]
	public class GenericVariable<T> : ScriptableObject //where T : struct
	{
#if UNITY_EDITOR
		[Multiline]
		public string DeveloperDescription = "";
#endif
		public T Value
		{
			get
			{
				return _value;
			}
			set
			{
				if (!_value.Equals(value))
				{
					_value = value;
					OnChangeValue();
				}
			}
		}
		[SerializeField]
		private T _value;

		private System.Action _onValueChange;
		

		public void SetValue(GenericVariable<T> value)
		{
			Value = value.Value;
		}

		public void RegisterAction(System.Action FctToRegister)
		{
			_onValueChange += FctToRegister;
		}

		public void UnregisterAction(System.Action FctToRegister)
		{
			_onValueChange -= FctToRegister;
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
