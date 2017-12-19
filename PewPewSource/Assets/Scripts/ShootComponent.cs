using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootComponent : MonoBehaviour {

	public Transform[] SpawnPoint;
	public Transform ContainerBullet;
	public GameObject[] Ammos;
	public float FireRate = 0.01f;
	public float StartFire = 0f;
	public int NSpawn = 1;

	private GameObject CurrentAmmo { get; set; }
	private int _currentIndexAmmo = 0;

	private void Awake()
	{
		if (Ammos.Length != 0)
		{
			CurrentAmmo = Ammos[0];
			InvokeRepeating("Shoot", StartFire, FireRate);
		}
	}



	public void Shoot()
	{
		for (int i = 0; i < NSpawn; i++)
		{
			SpawnProjectile(CurrentAmmo, ContainerBullet, SpawnPoint[i % SpawnPoint.Length].position);
		}
	}

	public void SwitchAmmo()
	{
		CurrentAmmo = Ammos[(++_currentIndexAmmo) % Ammos.Length];
	}

	private static void SpawnProjectile(GameObject PrefabAmmo, Transform Container, Vector3 Position)
	{
		var instance = GameObject.Instantiate<GameObject>(PrefabAmmo, Container, false);
		Transform instanceTrans = instance.transform;
		instanceTrans.position = Position;
	}
}
