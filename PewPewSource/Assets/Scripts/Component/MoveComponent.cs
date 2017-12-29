using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{
	public System.Action OnOutOfBounds;

	public Vector3 Position
	{
		get { return _trans.position; }
		set
		{
			if (GameBounds.IsOnDeathArea(value))
			{
				if (OnOutOfBounds != null)
					OnOutOfBounds();
			}
			else
				_trans.position = value;
		}
	}

	private Transform _trans;
	private Vector3 _pos;
	private MoveComponentConfig _config;

	private void Awake()
	{
		_trans = transform;
	}

	public void Init(MoveComponentConfig Config)
	{
		_config = Config;
		_pos = _trans.position;
	}

	public void Move(Vector2 DeltaMove)
	{
		_pos.x += DeltaMove.x * _config.Move.x;
		_pos.y += DeltaMove.y * _config.Move.y;

		if (GameBounds.IsOnDeathArea(_pos))
		{
			if (OnOutOfBounds != null)
				OnOutOfBounds();
		}
		else
			_trans.position = _pos;

		
	}
}
