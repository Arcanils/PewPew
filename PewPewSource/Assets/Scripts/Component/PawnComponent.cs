using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnComponent : MonoBehaviour
{
	public System.Action OnDeath;

	private ShootComponent _shootComp;
	private MoveComponent _moveComp;
	private Entity _entity;
	private PoolObjectComponent _poolObjectComponent;

	private void Awake()
	{
		GetBehaviours();
	}

	private void GetBehaviours()
	{
		_shootComp = GetComponent<ShootComponent>();
		_moveComp = GetComponent<MoveComponent>();
		_entity = GetComponent<Entity>();
		_poolObjectComponent = GetComponent<PoolObjectComponent>();
		if (_poolObjectComponent)
		{
			_poolObjectComponent.OnInitFromPool += Init;
			_poolObjectComponent.OnResetBeforePooling += Reset;
		}
	}

	public void Init()
	{
		if (_moveComp)
			_moveComp.Init();

		if (_entity)
			_entity.Init();

		if (_shootComp)
			_shootComp.Init();
	}

	public void Reset()
	{
		if (_shootComp)
			_shootComp.Reset();
	}

	public void Shoot()
	{
		_shootComp.Shoot();
	}

	public void SwitchAmmo()
	{
		_shootComp.SwitchAmmo();
	}

	public void Move(Vector2 DeltaMove)
	{
		_moveComp.Move(DeltaMove);
	}

	public void SetPosition(Vector3 NewPosition)
	{
		_moveComp.Position = NewPosition;
	}

	public Vector3 GetPosition()
	{
		return _moveComp.Position;
	}

	public void SetDirection(Vector3 EulerRotation)
	{

	}

	public void SelfDestroy()
	{
		if (OnDeath != null)
			OnDeath();

		if (_poolObjectComponent != null)
			_poolObjectComponent.BackToPool();
		else
			Destroy(gameObject);
	}
}
