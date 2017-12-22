using UnityEngine;

public class PoolObjectComponent : MonoBehaviour
{
	public System.Action OnInitFromPool;

	private PoolPrefab _refPool;

	public void SetPool(PoolPrefab RefPool)
	{
		_refPool = RefPool;
	}

	public void BackToPool()
	{
		_refPool.BackToPool(this);
	}

	public void InitObject()
	{
		if (OnInitFromPool != null)
			OnInitFromPool();
	}
}
