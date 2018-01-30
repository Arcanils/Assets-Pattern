using UnityEngine;

namespace AssetsPattern
{
	[CreateAssetMenu(fileName = "StringVar", menuName = "AssetsPattern/Variable/StringVar")]
	[System.Serializable]
	public class StringVariable : GenericVariable<string>
	{

	}
}