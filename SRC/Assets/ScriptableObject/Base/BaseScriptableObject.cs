using AssetsPattern;
using UnityEngine;

namespace CustomScriptable
{
	public abstract class BaseScriptableObject<TType> : ScriptableObject
	{
		[SerializeField]
		private TType _value;
		[SerializeField]
		private readonly ErrorHandling _errorHandle;

		protected BaseScriptableObject()
		{
			_errorHandle = new ErrorHandling();
		}

		public void SetValue(TType newValue)
		{
			_value = newValue;
			_errorHandle.RaiseSuccess();
		}

		public void RaiseError(string errorMsg = null)
		{
			_errorHandle.RaiseError(errorMsg);
		}

		public bool HasError()
		{
			return _errorHandle.HasError;
		}

		public bool GetValue(out TType value)
		{
			value = _value;
			return !_errorHandle.HasError;
		}
		public bool GetValue(out TType value, out string errorMsg)
		{
			value = _value;
			errorMsg = _errorHandle.ErrorMessage;
			return !_errorHandle.HasError;
		}
	}

	[System.Serializable]
	public class ErrorHandling
	{
		public GameEvent RaiseOnError;
		public GameEvent RaiseOnSuccess;

		public bool HasError;
		public string ErrorMessage;

		public void RaiseError(string errorMsg)
		{
			HasError = true;
			ErrorMessage = errorMsg;

			if (RaiseOnError != null)
				RaiseOnError.Raise();
		}

		public void RaiseSuccess()
		{
			HasError = false;
			ErrorMessage = null;

			if (RaiseOnSuccess != null)
				RaiseOnSuccess.Raise();
		}
	}
}
