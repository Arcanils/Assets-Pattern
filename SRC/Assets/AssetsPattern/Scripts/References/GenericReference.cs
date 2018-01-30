
using UnityEngine;

namespace AssetsPattern
{
	[System.Serializable]
	public class GenericReference<T, S> where S : GenericVariable<T>
	{
		public bool UseConstant = true;
		public T ConstantValue;
		public S Variable;

		private System.Action _onValueChange;

		public GenericReference()
		{ }

		public GenericReference(T value)
		{
			UseConstant = true;
			ConstantValue = value;
		}

		public T Value
		{
			get
			{
				return UseConstant ? ConstantValue : Variable.Value;
			}
			set
			{
				bool isNewValue = !Value.Equals(value);
				if (isNewValue)
				{
					if (UseConstant)
					{
						ConstantValue = value;
					}
					else
						Variable.Value = value;

				}
			}
		}


		public void RegisterAction(System.Action FctToRegister)
		{
			if (!UseConstant && Variable != null)
				Variable.RegisterAction(FctToRegister);
			else
				_onValueChange += FctToRegister;
		}

		public void UnregisterAction(System.Action FctToRegister)
		{
			if (!UseConstant && Variable != null)
				Variable.UnregisterAction(FctToRegister);
			else
				_onValueChange -= FctToRegister;
		}
		private void OnValueChange()
		{
			if (!UseConstant && Variable != null)
			{

			}
			else
			{
				if (_onValueChange != null)
					_onValueChange();
			}
		}
	}
}