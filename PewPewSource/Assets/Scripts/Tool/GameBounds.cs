using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBounds : MonoBehaviour {

	public float DistanceAreaBeforeDeath = 3f;

	private static Vector3 _TL;
	private static Vector3 _TR;
	private static Vector3 _BL;
	private static Vector3 _BR;
	private static Rect _rectSafeArea;

	public void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		CreateGameBounds();
	}
	public void Start()
	{
		InitGround(DistanceAreaBeforeDeath);
	}
	private static void InitGround(float DistanceAreaBeforeDeath)
	{
		var cam = Camera.main;
		var frustumHeight = 2.0f * -cam.transform.position.z * Mathf.Tan(cam.fieldOfView * 0.5f * Mathf.Deg2Rad);
		var frustumWidth = frustumHeight * cam.aspect + DistanceAreaBeforeDeath;
		frustumHeight += DistanceAreaBeforeDeath;
		_TL = new Vector3(frustumWidth / -2f, frustumHeight / 2f, 0f);
		_TR = new Vector3(frustumWidth / 2f, frustumHeight / 2f, 0f);
		_BL = new Vector3(frustumWidth / -2f, frustumHeight / -2f, 0f);
		_BR = new Vector3(frustumWidth / 2f, frustumHeight / -2f, 0f);
		_rectSafeArea = new Rect(_BL.x, _BL.y, frustumWidth, frustumHeight);
	}

	public static void CreateGameBounds()
	{
		Gizmos.DrawLine(_TL, _TR);
		Gizmos.DrawLine(_BR, _TR);
		Gizmos.DrawLine(_BR, _BL);
		Gizmos.DrawLine(_TL, _BL);
	}
	
	public static bool IsOnDeathArea(Vector3 PositionToTest)
	{
		return !_rectSafeArea.Contains(PositionToTest);
	}
}
