using UnityEngine;

namespace AssetsPattern
{
	[CreateAssetMenu(fileName = "IntVar", menuName = "AssetsPattern/Variable/IntVar")]
	[System.Serializable]
	public class IntVariable : GenericVariable<int>
	{
	}
}
