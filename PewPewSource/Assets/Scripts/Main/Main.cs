using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
	public static Main Instance { get; private set; }

	public LvlConfig[] LvlConfigs;

	public PoolManager PoolManagerInstance { get; private set; }
	public GameplayLoop GameplayLoopInstance { get; private set; }
	public EntityFactory EntityFactoryInstance { get; private set; }

	private LoaderLvl _loadLvl;

	public void Awake()
	{
		InitPoolManager();
		InitGameplayLoop();
		InitEntityFactory();
		InitLoaderLvl();
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
	private void InitEntityFactory()
	{
		EntityFactoryInstance = new EntityFactory(PoolManagerInstance);
	}

	private void InitLoaderLvl()
	{
		_loadLvl = new LoaderLvl(EntityFactoryInstance);
	}

	private IEnumerator MainGameplayEnum()
	{
		yield return new WaitForSeconds(0.1f);
		SpawnGame();
		while (true)
		{
			GameplayLoopInstance.TickFixed();
			yield return new WaitForFixedUpdate();
		}
	}

	private void SpawnGame()
	{
		_loadLvl.CreateLvl(LvlConfigs[0]);
	}
}
