using UnityEngine.UI;

namespace AssetsPattern
{
	public class UIButtonGameEvent : Button
	{
		public GameEvent[] EventsToRaise;

		protected override void Awake()
		{
			base.Awake();
			onClick.AddListener(RaiseEvents);
		}

		public void RaiseEvents()
		{
			for (var i = EventsToRaise.Length - 1; i >= 0; --i)
			{
				if (EventsToRaise[i] != null)
					EventsToRaise[i].Raise();
			}
		}
	}
}