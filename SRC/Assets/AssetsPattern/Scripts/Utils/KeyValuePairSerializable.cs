[System.Serializable]
public struct StringGameEventPair
{
	public string Key;
	public AssetsPattern.GameEvent Value;

	public StringGameEventPair(string Key, AssetsPattern.GameEvent Value)
	{
		this.Key = Key;
		this.Value = Value;
	}
}