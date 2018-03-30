using UnityEngine;

namespace AssetsPattern
{
	public abstract class AbstractGameEventListener : MonoBehaviour
	{
		[Tooltip("Events to register with.")]
		public GameEvent[] Events;


		protected virtual void OnEnable()
		{
			for (var iEvent = Events.Length - 1; iEvent >= 0; --iEvent)
			{
				if (Events[iEvent] != null)
					Events[iEvent].RegisterListener(this);
			}
		}

		protected virtual void OnDisable()
		{
			for (var iEvent = Events.Length - 1; iEvent >= 0; --iEvent)
			{
				if (Events[iEvent] != null)
					Events[iEvent].UnregisterListener(this);
			}
		}

		protected virtual void Reset()
		{
			Events = new GameEvent[1];
		}

		public abstract void OnEventRaised();
	}
}