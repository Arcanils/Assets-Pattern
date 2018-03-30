using UnityEngine;

namespace AssetsPattern
{
	[CreateAssetMenu(fileName = "StringVar", menuName = "AssetsPattern/Variable/String")]
	[System.Serializable]
	public class StringVariable : GenericVariable<string>
	{

	}
}