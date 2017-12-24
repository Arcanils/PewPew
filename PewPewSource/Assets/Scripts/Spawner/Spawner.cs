using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject PrefabEnemy;
	public Transform ContainerEnemy;
	public Transform[] SpawnPoints;
	public float DurationBeforeSpawn = 0.5f;

	public void Start()
	{
		StartCoroutine(LogicSpawnEnum());
	}

	public IEnumerator LogicSpawnEnum()
	{
		while(true)
		{
			yield return new WaitForSeconds(DurationBeforeSpawn);
			//Spawn();
		}
	}

	private void Spawn()
	{
		int randomIndex = Random.Range(0, SpawnPoints.Length);
		var instance = GameObject.Instantiate<GameObject>(PrefabEnemy, ContainerEnemy, true);
		var instanceTrans = instance.transform;
		instanceTrans.position = SpawnPoints[randomIndex].position;
	}
}
