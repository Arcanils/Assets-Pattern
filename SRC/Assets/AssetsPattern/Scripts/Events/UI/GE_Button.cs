using AssetsPattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GE_Button : Button
{
	public GameEvent[] EventsToRaise;

	protected override void Awake()
	{
		base.Awake();
		onClick.AddListener(() => RaiseEvents());
	}

	public void RaiseEvents()
	{
		for (int i = EventsToRaise.Length - 1; i >= 0; --i)
		{
			if (EventsToRaise[i] != null)
				EventsToRaise[i].Raise();
		}
	}
}
