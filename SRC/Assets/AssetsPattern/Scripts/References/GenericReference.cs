namespace AssetsPattern
{
	[System.Serializable]
	public class GenericReference<TType, TGenericVariable> where TGenericVariable : GenericVariable<TType>
	{
		public bool UseConstant = true;
		public TType ConstantValue;
		public TGenericVariable Variable;

		private System.Action _onValueChange;

		public GenericReference()
		{ }

		public GenericReference(TType value)
		{
			UseConstant = true;
			ConstantValue = value;
		}

		public TType Value
		{
			get
			{
				return UseConstant ? ConstantValue : Variable.Value;
			}
			set
			{
				var isNewValue = !Value.Equals(value);
				if (!isNewValue) return;
				if (UseConstant)
					ConstantValue = value;
				else
					Variable.Value = value;
			}
		}


		public void AddListenerToOnValueChange(System.Action callback)
		{
			if (!UseConstant && Variable != null)
				Variable.AddListernerToOnValueChange(callback);
			else
				_onValueChange += callback;
		}

		public void RemoveListenerToOnValueChange(System.Action callback)
		{
			if (!UseConstant && Variable != null)
				Variable.RemoveListernerToOnValueChange(callback);
			else
				_onValueChange -= callback;
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