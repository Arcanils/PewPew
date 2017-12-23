using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseController : MonoBehaviour
{
	public PoolObjectComponent PawnToInstanciate;


	public System.Action OnInit;
	public System.Action OnDestroy;

	protected PawnComponent _refPawn;
	protected PoolObjectComponent _poolObjectComponent;

	public abstract void TickFixed();


	public void Awake()
	{
		_poolObjectComponent = GetComponent<PoolObjectComponent>();

		if (_poolObjectComponent != null)
		{
			_poolObjectComponent.OnInitFromPool += Init;
		}
	}

	public virtual void Init()
	{
		_refPawn = Main.Instance.PoolManagerInstance.GetItem<PawnComponent>(PawnToInstanciate);
		if (_refPawn == null)
		{
			Debug.LogError("[BaseController/Init]: Leak from pool !! Prefab whitout PawnComponent : " + PawnToInstanciate.name);
		}
		else
		{
			//Bind Trans ?
			Main.Instance.GameplayLoopInstance.SubElement(this);
		}
	}

	public virtual void Destroy()
	{
		Main.Instance.GameplayLoopInstance.RemoveElement(this);

		if (_refPawn)
			_refPawn.SelfDestroy();

		if (OnDestroy != null)
			OnDestroy();

		if (_poolObjectComponent != null)
			_poolObjectComponent.BackToPool();
		else
			Destroy(gameObject);
	}
}
