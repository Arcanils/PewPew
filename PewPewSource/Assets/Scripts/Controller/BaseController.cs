using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseController : MonoBehaviour
{
	public PoolObjectComponent PawnToInstanciate;

	protected PawnComponent _refPawn;
	protected PoolObjectComponent _poolObjectComponent;

	public abstract void TickFixed();


	public virtual void Awake()
	{
		_poolObjectComponent = GetComponent<PoolObjectComponent>();

		if (_poolObjectComponent != null)
		{
			_poolObjectComponent.OnInitFromPool += Init;
			_poolObjectComponent.OnResetBeforeBackToPool += Reset;
		}
	}

	public virtual void Init()
	{
		_refPawn = Main.Instance.PoolManagerInstance.GetItem<PawnComponent>(PawnToInstanciate, transform.position);
		if (_refPawn == null)
		{
			Debug.LogError("[BaseController/Init]: Leak from pool !! Prefab whitout PawnComponent : " + PawnToInstanciate.name);
		}
		else
		{
			_refPawn.OnDeath += Destroy;
			Main.Instance.GameplayLoopInstance.SubElement(this);
		}
	}

	public virtual void Reset()
	{
		Main.Instance.GameplayLoopInstance.RemoveElement(this);

		if (_refPawn)
		{
			_refPawn.OnDeath -= Destroy;
			//_refPawn.SelfDestroy();
			_refPawn = null;
		}
	}

	public virtual void Destroy()
	{
		if (_poolObjectComponent != null)
			_poolObjectComponent.BackToPool();
		else
			Destroy(gameObject);
	}
}
