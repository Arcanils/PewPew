using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseController : AbstractController
{

	public Vector3 PawnPosition
	{
		get
		{
			return _refPawn.GetPosition();
		}
	}

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
			_poolObjectComponent.OnResetBeforeBackToPool += ResetAfterDisable;
		}
	}

	public override void Init(ControllerComponentConfig Config)
	{
		_config = Config;
		if (_config != null && _config.WatcherSets != null && _config.WatcherSets.Length > 0)
		{
			for (int i = _config.WatcherSets.Length - 1; i >= 0; --i)
			{
				_config.WatcherSets[i].Add(this);
			}
		}
		Main.Instance.GameplayLoopInstance.SubElement(this);
	}

	public override void ResetAfterDisable()
	{
		Main.Instance.GameplayLoopInstance.RemoveElement(this);

		if (_refPawn)
		{
			_refPawn.OnDeath -= Destroy;
			_refPawn = null;
		}

		if (_config != null && _config.WatcherSets != null && _config.WatcherSets.Length > 0)
		{
			for (int i = _config.WatcherSets.Length - 1; i >= 0; --i)
			{
				_config.WatcherSets[i].Remove(this);
				Debug.LogError(this.GetType());
			}
		}

		_config = null;
	}

	public override void Destroy()
	{
		if (_poolObjectComponent != null)
			_poolObjectComponent.BackToPool();
		else
			Destroy(gameObject);
	}

	public override void TickMove(float DeltaTime)
	{
		//Move
	}

	public override void TickEntity(float DeltaTime)
	{
		_refPawn.TickBody(DeltaTime);
	}

	public override void TickShoot(float DeltaTime)
	{
		_refPawn.TickShoot(DeltaTime);
	}
}
