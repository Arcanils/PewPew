using UnityEngine;

class PoolObjectComponent : MonoBehaviour
{
	private PoolPrefab _refPool;

	public void SetPool(PoolPrefab RefPool)
	{
		_refPool = RefPool;
	}

	public void BackToPool()
	{
		_refPool.BackToPool(this);
	}
}
