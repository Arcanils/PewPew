using UnityEngine;

public class PoolObjectComponent : MonoBehaviour
{
	public System.Action OnInitFromPool;
	public System.Action OnResetBeforePooling;

	private PoolPrefab _refPool;

	public void SetPool(PoolPrefab RefPool)
	{
		_refPool = RefPool;
	}

	public void BackToPool()
	{
		if (OnResetBeforePooling != null)
			OnResetBeforePooling();

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
