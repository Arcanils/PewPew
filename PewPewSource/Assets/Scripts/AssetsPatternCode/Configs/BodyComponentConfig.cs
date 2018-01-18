using AssetsPattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BodyComponentConfig
{
	public FloatReference HP;
	public bool IsImmortal;
	public bool CanDamage;
	public float Damage;
	public float DurationImmortal;
}
