using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootComponent : MonoBehaviour {

	public Transform[] SpawnPoint;
	public Transform ContainerBullet;
	public PoolObjectComponent[] Ammos;
	public float FireRate = 0.01f;
	public float StartFire = 0f;
	public int NSpawn = 1;

	private PoolObjectComponent CurrentAmmo { get; set; }
	private int _currentIndexAmmo = 0;
	
	public void Init()
	{
		if (Ammos.Length != 0 && Ammos[0] != null)
		{
			CurrentAmmo = Ammos[0];
			InvokeRepeating("Shoot", StartFire, FireRate);
		}
	}

	public void Reset()
	{
		if (Ammos.Length != 0 && Ammos[0] != null)
		{
			CurrentAmmo = Ammos[0];
			CancelInvoke("Shoot");
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

	private static void SpawnProjectile(PoolObjectComponent PrefabAmmo, Transform Container, Vector3 Position)
	{
		var instance = Main.Instance.PoolManagerInstance.GetItem(PrefabAmmo, Position);
		/*
		Transform instanceTrans = instance.transform;
		instanceTrans.position = Position;*/
	}
}
