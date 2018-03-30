namespace AssetsPattern
{
	[System.Serializable]
	public struct StringGameEventPair
	{
		public string Key;
		public GameEvent Value;

		public StringGameEventPair(string key, GameEvent value)
		{
			Key = key;
			Value = value;
		}
	}

}
