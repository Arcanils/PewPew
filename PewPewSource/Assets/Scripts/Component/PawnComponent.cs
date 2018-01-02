using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnComponent : MonoBehaviour
{
	public System.Action OnDeath;

	private ShootComponent _shootComp;
	private MoveComponent _moveComp;
	private BodyComponent _bodyComp;
	private PoolObjectComponent _poolObjectComponent;

	private void Awake()
	{
		GetBehaviours();
	}

	private void GetBehaviours()
	{
		_shootComp = GetComponent<ShootComponent>();
		_moveComp = GetComponent<MoveComponent>();
		_bodyComp = GetComponent<BodyComponent>();
		_poolObjectComponent = GetComponent<PoolObjectComponent>();
		if (_poolObjectComponent)
		{
			_poolObjectComponent.OnResetBeforeBackToPool += ResetAfterDisable;
		}

		if (_moveComp)
			_moveComp.OnOutOfBounds += SelfDestroy;
		if (_bodyComp)
			_bodyComp.OnDeath += SelfDestroy;
	}

	public void Init(PawnStructConfig Config)
	{
		if (_moveComp)
			_moveComp.Init(Config.MoveConfig);

		if (_bodyComp)
			_bodyComp.Init(Config.BodyConfig);

		if (_shootComp)
			_shootComp.Init(Config.ShootConfig);
	}

	public void ResetAfterDisable()
	{
		if (_shootComp)
			_shootComp.ResetAfterDisable();
	}

	public void Shoot()
	{
		_shootComp.Shoot();
	}

	public void SwitchAmmo(AmmoData NewAmmo, bool AutoFire)
	{
		_shootComp.SwitchAmmo(NewAmmo, AutoFire);
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
		if (name.Contains("Enemy"))
			Debug.LogError("ENEMY PAWN DEAD !");
		if (OnDeath != null)
			OnDeath();

		if (_poolObjectComponent != null)
			_poolObjectComponent.BackToPool();
		else
		{
			Destroy(gameObject);
		}
	}
	
}
