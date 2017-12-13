using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnComponent : MonoBehaviour
{

	private ShootComponent _shootComp;
	private MoveComponent _moveComp;
	private Entity _entity;

	private void Awake()
	{
		GetBehaviours();
	}

	private void GetBehaviours()
	{
		_shootComp = GetComponent<ShootComponent>();
		_moveComp = GetComponent<MoveComponent>();
		_entity = GetComponent<Entity>();
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

	public void SelfDestroy()
	{

	}
}
