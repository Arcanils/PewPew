using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseController : AbstractController
{
	public override void SetPawn(PawnComponent Pawn)
	{
		if (Pawn)
		{
			_refPawn = Pawn;
			_refPawn.OnDeath += Destroy;
		}
	}

	public override void Awake()
	{
		_poolObjectComponent = GetComponent<PoolObjectComponent>();

		if (_poolObjectComponent != null)
		{
			_poolObjectComponent.OnInitFromPool += Init;
			_poolObjectComponent.OnResetBeforeBackToPool += Reset;
		}
	}

	public override void Init()
	{
		Main.Instance.GameplayLoopInstance.SubElement(this);
	}

	public override void Reset()
	{
		Main.Instance.GameplayLoopInstance.RemoveElement(this);

		if (_refPawn)
		{
			_refPawn.OnDeath -= Destroy;
			_refPawn = null;
		}
	}

	public override void Destroy()
	{
		if (_poolObjectComponent != null)
			_poolObjectComponent.BackToPool();
		else
			Destroy(gameObject);
	}
}
