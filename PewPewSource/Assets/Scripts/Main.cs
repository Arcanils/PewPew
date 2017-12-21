using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

	
	private PoolManager _poolManager;

	public void Awake()
	{
		InitPoolManager();
	}

	private void InitPoolManager()
	{
		var goContainer = new GameObject("[PoolContainer]");
		var transContainer = goContainer.transform;
		_poolManager = new PoolManager(transContainer);
	}
}
