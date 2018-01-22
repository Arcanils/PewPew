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
		get { return _deltaPos; }
		set
		{
			_deltaPos = value;
			SetPosition();
		}
	}

	public Quaternion Direction
	{
		get { return _dir; }
		set
		{
			_dir = value;
		}
	}

	private Transform _trans;
	private Vector3 _deltaPos;
	private Vector3 _currentPos;
	private Quaternion _dir;
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
		_currentPos = _trans.position;
		_typeMove = (int)ETypeMove.Manual;
		_dir = Quaternion.Euler(Config.Direction);
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
		_deltaPos += _currentPoint - _prevPoint;
	}

	private void ManualMove(float SpeedX, float SpeedY, float DeltaTime)
	{
		_deltaPos.x += SpeedX * _config.Move.x * DeltaTime;
		_deltaPos.y += SpeedY * _config.Move.y * DeltaTime;

		SetPosition();
	}

	private void SetPosition()
	{	
		_currentPos += _dir * _deltaPos ;
		_deltaPos.Set(0f, 0f, 0f);

		if (_config != null && _config.BlockedOnScreen)
		{ 
			GameBounds.ClampsThisPosition(ref _currentPos);
			_trans.position = _currentPos;
		}
		else
		{
			if (GameBounds.IsOnDeathArea(_currentPos))
			{
				if (OnOutOfBounds != null)
					OnOutOfBounds();
			}
			else
				_trans.position = _currentPos;
		}
	}
}
