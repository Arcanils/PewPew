using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : BaseController
{
	public PoolObjectComponent PrefabEnemy;

	
	public Vector2 VecDir;
	

	public override void Init()
	{

	}

	public override void TickFixed()
	{
		if (_refPawn != null)
			_refPawn.Move(VecDir * Time.fixedDeltaTime);
	}
}
