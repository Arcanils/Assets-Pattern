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
        private readonly List<AbstractGameEventListener> _eventListeners = 
            new List<AbstractGameEventListener>();

		private System.Action _eventScriptListeners;

		public void Raise()
		{
			if (_eventScriptListeners != null)
				_eventScriptListeners();

			for (var i = _eventListeners.Count - 1; i >= 0; i--)
				_eventListeners[i].OnEventRaised();
		}

        public void RegisterListener(AbstractGameEventListener listener)
        {
            if (!_eventListeners.Contains(listener))
                _eventListeners.Add(listener);
        }

        public void UnregisterListener(AbstractGameEventListener listener)
        {
            if (_eventListeners.Contains(listener))
                _eventListeners.Remove(listener);
        }

		public void RegisterAction(System.Action action)
		{
			_eventScriptListeners += action;
		}

		public void UnregisterAction(System.Action action)
		{
			_eventScriptListeners -= action;
		}

		public void GetEvents(out List<string> listStrActions, out List<string> listStrListener)
		{
			listStrActions = new List<string>();
			if (_eventScriptListeners != null)
			{
				var data = _eventScriptListeners.GetInvocationList();
				for (var i = 0; i < data.Length; i++)
				{
					listStrActions.Add("T:" + data[i].Target + "|M:" + data[i].Method.Name);
				}

			}
			listStrListener = new List<string>();

			for (var i = 0; i < _eventListeners.Count; i++)
			{
				listStrListener.Add("T:" + _eventListeners[i].name);
			}
		}
	}
}