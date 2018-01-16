using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBounds : MonoBehaviour {

	public float DistanceAreaBeforeDeath = 3f;
	private static Vector3 _TL;
	private static Vector3 _TR;
	private static Vector3 _BL;
	private static Vector3 _BR;
	private static Vector3 _camTL;
	private static Vector3 _camTR;
	private static Vector3 _camBL;
	private static Vector3 _camBR;
	private static Rect _rectSafeArea;

	private static Transform _camTrans;
	private static Camera _cam;

	public void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		CreateGameBounds();
	}

	public void Start()
	{
		_cam = Main.Instance.GameCameraInstance.GetComponent<Camera>();
		_camTrans = _cam.transform;
	}

	public void Update()
	{
		InitGround(DistanceAreaBeforeDeath);
	}
	private static void InitGround(float DistanceAreaBeforeDeath)
	{
		var frustumHeight = _cam.orthographicSize * 2;
		var frustumWidth = frustumHeight * _cam.aspect;
		_camTL = new Vector3(frustumWidth / -2f + _camTrans.position.x, frustumHeight / 2f + _camTrans.position.y, 0f);
		_camTR = new Vector3(frustumWidth / 2f + _camTrans.position.x, frustumHeight / 2f + _camTrans.position.y, 0f);
		_camBL = new Vector3(frustumWidth / -2f + _camTrans.position.x, frustumHeight / -2f + _camTrans.position.y, 0f);
		_camBR = new Vector3(frustumWidth / 2f + _camTrans.position.x, frustumHeight / -2f + _camTrans.position.y, 0f);
		frustumWidth += DistanceAreaBeforeDeath;
		frustumHeight += DistanceAreaBeforeDeath;
		_TL = new Vector3(frustumWidth / -2f + _camTrans.position.x, frustumHeight / 2f + _camTrans.position.y, 0f);
		_TR = new Vector3(frustumWidth / 2f + _camTrans.position.x, frustumHeight / 2f + _camTrans.position.y, 0f);
		_BL = new Vector3(frustumWidth / -2f + _camTrans.position.x, frustumHeight / -2f + _camTrans.position.y, 0f);
		_BR = new Vector3(frustumWidth / 2f + _camTrans.position.x, frustumHeight / -2f + _camTrans.position.y, 0f);
		_rectSafeArea = new Rect(_BL.x, _BL.y, frustumWidth, frustumHeight);
	}

	public static void CreateGameBounds()
	{
		Gizmos.DrawLine(_TL, _TR);
		Gizmos.DrawLine(_BR, _TR);
		Gizmos.DrawLine(_BR, _BL);
		Gizmos.DrawLine(_TL, _BL);

		Gizmos.DrawLine(_camTL, _camTR);
		Gizmos.DrawLine(_camBR, _camTR);
		Gizmos.DrawLine(_camBR, _camBL);
		Gizmos.DrawLine(_camTL, _camBL);
	}
	
	public static bool IsOnDeathArea(Vector3 PositionToTest)
	{
		return !_rectSafeArea.Contains(PositionToTest);
	}

	public static void ClampsThisPosition(ref Vector3 PositionToClamp)
	{
		PositionToClamp.x = Mathf.Clamp(PositionToClamp.x, _camBL.x, _camTR.x);
		PositionToClamp.y = Mathf.Clamp(PositionToClamp.y, _camBL.y, _camTR.y);
	}
}
