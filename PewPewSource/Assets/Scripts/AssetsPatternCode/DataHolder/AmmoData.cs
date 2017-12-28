using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AmmoData : ScriptableObject
{
	public PawnControllerData Bullet;
	public float FireRate;
	public float FireStart;
	public int NElement;
}
