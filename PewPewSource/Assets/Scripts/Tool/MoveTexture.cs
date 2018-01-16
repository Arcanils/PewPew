using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTexture : MonoBehaviour {

	public Vector2 VecMove;

	private MeshRenderer _meshRend;
	private Vector2 _currentOffset;

	public void Awake()
	{
		_meshRend = GetComponent<MeshRenderer>();
	}

	void Update ()
	{
		_currentOffset += VecMove * Time.deltaTime;
		_meshRend.sharedMaterial.SetTextureOffset("_MainTex", _currentOffset);
	}
}
