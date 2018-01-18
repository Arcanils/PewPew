using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{
	public enum ETypeMove
	{
		Manual,
		Spline,
	}
	public System.Action OnOutOfBounds;

	public Vector3 Position
	{
		get { return _pos; }
		set
		{
			_pos = value;
			SetPosition();
		}
	}

	private Transform _trans;
	private Vector3 _pos;
	private MoveComponentConfig _config;
	private BezierSpline _curveToEvaluate;

	private delegate void FunctionMoveTick(float SpeedX, float SpeedY, float DeltaTime);
	private FunctionMoveTick[] _fctMoveTick;

	private float _percSpline;
	private Vector3 _prevPoint;
	private Vector3 _currentPoint;
	private int _typeMove;

	private void Awake()
	{
		_trans = transform;
		_fctMoveTick = new FunctionMoveTick[]
		{
			ManualMove,
			SplineMove,
		};
	}

	public void Init(MoveComponentConfig Config)
	{
		_config = Config;
		_pos = _trans.position;
		_typeMove = (int)ETypeMove.Manual;
	}

	public void Move(float SpeedX, float SpeedY, float DeltaTime)
	{
		_fctMoveTick[_typeMove](SpeedX, SpeedY, DeltaTime);
	}

	public void SetSpline(BezierSpline Spline)
	{
		if (Spline != null)
		{
			_curveToEvaluate = Spline;
			_percSpline = 0f;
			_prevPoint.Set(0f, 0f, 0f);
			_typeMove = (int)ETypeMove.Spline;
		}
	}

	private void SplineMove(float SpeedX, float SpeedY, float DeltaTime)
	{
		_percSpline += DeltaTime * SpeedX;
		_prevPoint = _currentPoint;
		_currentPoint = _curveToEvaluate.GetPoint(_percSpline);
		_pos += _currentPoint - _prevPoint;
	}

	private void ManualMove(float SpeedX, float SpeedY, float DeltaTime)
	{
		_pos.x += SpeedX * _config.Move.x;
		_pos.y += SpeedY * _config.Move.y;

		SetPosition();
	}

	private void SetPosition()
	{
		if (_config != null && _config.BlockedOnScreen)
		{
			GameBounds.ClampsThisPosition(ref _pos);

			_trans.position = _pos;
		}
		else
		{
			if (GameBounds.IsOnDeathArea(_pos))
			{
				if (OnOutOfBounds != null)
					OnOutOfBounds();
			}
			else
				_trans.position = _pos;
		}
	}
}
