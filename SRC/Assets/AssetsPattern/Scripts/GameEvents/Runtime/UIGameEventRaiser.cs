using System.Linq;
using UnityEngine;

namespace AssetsPattern
{
	public class UIGameEventRaiser : MonoBehaviour
	{
		public StringGameEventPair[] Events;

		public void RaiseAllEvents()
		{
			for (int i = 0, iLength = Events.Length; i < iLength; ++i)
			{
				if (Events[i].Value != null)
					Events[i].Value.Raise();
			}
		}

		public void RaiseEvent(int index)
		{
			if (index < 0 || Events.Length <= index)
				return;


			var item = Events[index].Value;
			if (item != null)
				item.Raise();
		}

		public void RaiseEvent(string key)
		{
			if (string.IsNullOrEmpty(key))
			{
				return;
			}

			var item = Events.FirstOrDefault(keyvaluepair => keyvaluepair.Key == key).Value;
			if (item != null)
				item.Raise();
		}
	}
}

