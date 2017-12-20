using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class GenericPool<TObject> where TObject : Object, new()
{
	public int PoolSize = 20;

	private List<TObject> _pool;
	private List<bool> _inUse;

	public GenericPool()
	{
		FillPool();
	}


	public TObject GetItem()
	{
		for (int i = 0; i < PoolSize; ++i)
		{
			if (!_inUse[i])
			{
				_inUse[i] = true;
				return _pool[i];
			}
		}

		return CreateNewItem();
	}

	public bool ReturnItem(TObject Item)
	{
		for (int i = 0; i < PoolSize; ++i)
		{
			if (Item == _pool[i])
			{
				_inUse[i] = false;
				return true;
			}
		}

		return false;
	}

	private TObject CreateNewItem()
	{
		_pool.Add(new TObject());
		_inUse.Add(false);
		return _pool[PoolSize++];
	}

	private void FillPool()
	{
		_pool = new List<TObject>(PoolSize);
		_inUse = new List<bool>(PoolSize);

		for (int i = 0; i < PoolSize; ++i)
		{
			_pool[i] = new TObject();
		}
	}

};

class PoolPrefab
{
	public GameObject Prefab;
	public int PoolSize = 20;

	private List<GameObject> _pool;
	private List<bool> _inUse;
	private Transform _container;


	public GameObject GetItem()
	{
		for (int i = 0; i < PoolSize; ++i)
		{
			if (!_inUse[i])
			{
				_inUse[i] = true;
				_pool[i].SetActive(true);
				return _pool[i];
			}
		}

		return CreateNewItem();
	}

	private GameObject CreateNewItem()
	{
		var newInstance = GameObject.Instantiate<GameObject>(Prefab, _container, true);
		_pool.Add(newInstance);
		_inUse.Add(false);
		return _pool[PoolSize++];
	}

	private void FillPool()
	{
		_pool = new List<GameObject>(PoolSize);
		_inUse = new List<bool>(PoolSize);

		for (int i = 0; i < PoolSize; ++i)
		{
			_pool[i] = GameObject.Instantiate<GameObject>(Prefab, _container, true);
			_pool[i].SetActive(false);
		}
	}
}
