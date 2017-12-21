using UnityEngine;

class PoolInitializer : MonoBehaviour
{
	[System.Serializable]
	public struct DataPool
	{
		public PoolObjectComponent Prefab;
		public int SizePreload;

		public DataPool(PoolObjectComponent Prefab, int SizePreload)
		{
			this.Prefab = Prefab;
			this.SizePreload = SizePreload;
		}
	}

	public DataPool[] DataPoolPrefab;

	public void Start()
	{

	}
}