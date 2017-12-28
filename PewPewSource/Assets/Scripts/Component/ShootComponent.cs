using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootComponent : MonoBehaviour {

	public Transform[] SpawnPoint;

	private AmmoData CurrentAmmo { get; set; }
	private int _currentIndexAmmo = 0;

	public void Awake()
	{
		if (SpawnPoint == null || SpawnPoint.Length == 0)
			SpawnPoint = new Transform[] { transform };
	}

	public void Init()
	{

	}

	public void InitFire()
	{
		if (CurrentAmmo != null)
			InvokeRepeating("Shoot", CurrentAmmo.FireStart, CurrentAmmo.FireRate);
	}

	public void Reset()
	{
		if (CurrentAmmo != null)
			CancelInvoke("Shoot");
	}



	public void Shoot()
	{
		for (int i = 0; i < SpawnPoint.Length; i++)
		{
			SpawnProjectile(CurrentAmmo, SpawnPoint[i].position);
		}
	}

	public void SwitchAmmo(AmmoData NewAmmo, bool AutoFire = false)
	{
		CurrentAmmo = NewAmmo;
		Reset();
		if (AutoFire)
			InitFire();
	}

	private static void SpawnProjectile(AmmoData Ammo, Vector3 Position)
	{
		var instance = Main.Instance.EntityFactoryInstance.GetNewEntity(Ammo.Bullet, Position);
		/*
		Transform instanceTrans = instance.transform;
		instanceTrans.position = Position;*/
	}
}
