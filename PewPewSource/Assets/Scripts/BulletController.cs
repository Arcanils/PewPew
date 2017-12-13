using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	public Vector3 Speed = new Vector3(100, 0f, 0f);
	public float DeathTime = 2;

	private Transform _trans;

	public void Awake()
	{
		_trans = transform;
		Destroy(gameObject, DeathTime);
	}

	private void FixedUpdate()
	{
		_trans.position += Speed * Time.fixedDeltaTime;
	}
}
