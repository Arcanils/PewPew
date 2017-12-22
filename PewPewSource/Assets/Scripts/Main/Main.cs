using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

	public static Main Instance { get; private set; }
	public PoolManager PoolManagerInstance { get; private set; }

	public void Awake()
	{
		InitPoolManager();
		Instance = this;
	}

	private void InitPoolManager()
	{
		var goContainer = new GameObject("[PoolContainer]");
		var transContainer = goContainer.transform;
		PoolManagerInstance = new PoolManager(transContainer);
	}
}
