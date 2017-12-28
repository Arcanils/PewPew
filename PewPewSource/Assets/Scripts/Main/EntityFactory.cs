using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFactory
{
	private PoolManager _pool;


	public EntityFactory(PoolManager Pool)
	{
		Init(Pool);
	}


	public void Init(PoolManager Pool)
	{
		_pool = Pool;
	}
	public PawnComponent GetNewPawn(PawnControllerData Data, Vector3 Position)
	{
		return null;
	}

	public BaseController GetNewController(PawnControllerData Data, Vector3 Position)
	{
		return null;
	}

	public GameObject GetNewEntity(PawnControllerData Data, Vector3 Position)
	{
		return null;
	}
}
