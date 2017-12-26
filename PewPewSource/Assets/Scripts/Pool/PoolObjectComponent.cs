using UnityEngine;

public class PoolObjectComponent : MonoBehaviour
{
	public System.Action OnInitFromPool;
	public System.Action OnResetBeforeBackToPool;

	private PoolPrefab _refPool;

	public void SetPool(PoolPrefab RefPool)
	{
		_refPool = RefPool;
	}

	public void BackToPool()
	{
		if (OnResetBeforeBackToPool != null)
			OnResetBeforeBackToPool();

		if (_refPool == null)
			Debug.LogError(name);
		else
			_refPool.BackToPool(this);
	}

	public void InitObject()
	{
		if (OnInitFromPool != null)
			OnInitFromPool();
	}
}
