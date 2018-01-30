using System.Collections.Generic;
using UnityEngine;

namespace AssetsPattern
{
    [CreateAssetMenu(fileName="GameEvent",  menuName= "AssetsPattern/Event/GameEvent")]
    public class GameEvent : ScriptableObject
    {
        /// <summary>
        /// The list of listeners that this event will notify if it is raised.
        /// </summary>
        private readonly List<GameEventListener> _eventListeners = 
            new List<GameEventListener>();

		private System.Action _eventScriptListeners;

		public void Raise()
		{
			if (_eventScriptListeners != null)
				_eventScriptListeners();

			for (int i = _eventListeners.Count - 1; i >= 0; i--)
				_eventListeners[i].OnEventRaised();
		}

        public void RegisterListener(GameEventListener listener)
        {
            if (!_eventListeners.Contains(listener))
                _eventListeners.Add(listener);
        }

        public void UnregisterListener(GameEventListener listener)
        {
            if (_eventListeners.Contains(listener))
                _eventListeners.Remove(listener);
        }

		public void RegisterAction(System.Action Delegate)
		{
			_eventScriptListeners += Delegate;
		}

		public void UnregisterAction(System.Action Delegate)
		{
			_eventScriptListeners -= Delegate;
		}

		public void GetEvents(out List<string> ListStrActions, out List<string> ListStrGEL)
		{
			ListStrActions = new List<string>();
			if (_eventScriptListeners != null)
			{
				var data = _eventScriptListeners.GetInvocationList();
				for (int i = 0; i < data.Length; i++)
				{
					ListStrActions.Add("T:" + data[i].Target + "|M:" + data[i].Method.Name);
				}

			}
			ListStrGEL = new List<string>();

			for (int i = 0; i < _eventListeners.Count; i++)
			{
				ListStrGEL.Add("T:" + _eventListeners[i].name);
			}
		}
	}
}