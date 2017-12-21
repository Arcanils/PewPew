using System.Collections.Generic;
using UnityEngine;

class PoolManager
{
	private Dictionary<PoolObjectComponent, PoolPrefab> _mapPools;

	private readonly Transform _container;

	public PoolManager() { }

	public PoolManager(Transform Container)
	{
		_container = Container;
		_mapPools = new Dictionary<PoolObjectComponent, PoolPrefab>();
	}

	public void CreatePool(PoolObjectComponent PrefabToPool, int Size)
	{
		if (_mapPools.ContainsKey(PrefabToPool))
			return;

		GameObject goContainer = new GameObject("[" + PrefabToPool.name + "]");
		Transform transContainer = goContainer.transform;
		transContainer.parent = _container;
		_mapPools[PrefabToPool] = new PoolPrefab(PrefabToPool, transContainer, Size);
	}

	public PoolObjectComponent GetItem(PoolObjectComponent PrefabRef)
	{
		return _mapPools[PrefabRef].GetItem();
	}
}