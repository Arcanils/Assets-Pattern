using UnityEngine;

namespace AssetsPattern
{
	[CreateAssetMenu(fileName = "IntVar", menuName = "AssetsPattern/Variable/Int")]
	[System.Serializable]
	public class IntVariable : GenericVariable<int>
	{
	}
}
