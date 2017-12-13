using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{

	public float SpeedX = 10;
	public float SpeedY = 10;

	private Transform _trans;
	private Vector3 _pos;

	private void Awake()
	{
		_trans = transform;
		_pos = _trans.position;
	}

	public void Move(Vector2 DeltaMove)
	{
		_pos.x += DeltaMove.x * SpeedX;
		_pos.y += DeltaMove.y * SpeedX;
		_trans.position = _pos;
	}
}
