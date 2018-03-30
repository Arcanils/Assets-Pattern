namespace AssetsPattern
{
	public class GEListenerToTextField : AbstractGameEventListener
	{
		public IntReference Value;
		public UnityEngine.UI.Text TextField;

		public override void OnEventRaised()
		{
			TextField.text = Value.Value.ToString();
		}
	}
}
