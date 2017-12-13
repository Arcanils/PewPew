using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootComponent : MonoBehaviour {

	public Transform SpawnPoint;
	public Transform ContainerBullet;
	public GameObject[] Ammos;
	public float FireRate = 0.01f;
	public float StartFire = 0f;

	private GameObject CurrentAmmo { get; set; }
	private int _currentIndexAmmo = 0;

	private void Awake()
	{
		CurrentAmmo = Ammos[0];
		InvokeRepeating("Shoot", StartFire, FireRate);
	}



	public void Shoot()
	{
		SpawnProjectile();
	}

	public void SwitchAmmo()
	{
		CurrentAmmo = Ammos[(++_currentIndexAmmo) % Ammos.Length];
	}

	private void SpawnProjectile()
	{
		var instance = GameObject.Instantiate<GameObject>(CurrentAmmo, ContainerBullet, false);
		Transform instanceTrans = instance.transform;
		instanceTrans.position = SpawnPoint.position;
	}
}
