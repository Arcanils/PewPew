using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

	public static Main Instance { get; private set; }
	public PoolManager PoolManagerInstance { get; private set; }
	public GameplayLoop GameplayLoopInstance { get; private set; }

	public void Awake()
	{
		InitPoolManager();
		InitGameplayLoop();
		Instance = this;
	}

	public void Start()
	{
		StartCoroutine(MainGameplayEnum());
	}

	private void InitPoolManager()
	{
		var goContainer = new GameObject("[PoolContainer]");
		var transContainer = goContainer.transform;
		PoolManagerInstance = new PoolManager(transContainer);
	}
	private void InitGameplayLoop()
	{
		GameplayLoopInstance = new GameplayLoop();
	}

	private IEnumerator MainGameplayEnum()
	{
		while(true)
		{
			GameplayLoopInstance.TickFixed();
			yield return new WaitForFixedUpdate();
		}
	}

	private void SpawnGame()
	{

	}
}
