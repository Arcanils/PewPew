using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
	public int HPBase = 1;
	public int DMG;
	public bool ApplyDMG;
	public int Score = 100;

	private int _HP;

	public void Init()
	{
		_HP = HPBase;
	}

	public void OnCollisionEnter2D(Collision2D collision)
	{
		if (!ApplyDMG)
			return;

		var OtherEntity = collision.gameObject.GetComponent<Entity>();

		if (OtherEntity)
		{
			LaunchAttack(OtherEntity);
		}

		Destroy(gameObject);
	}

	public void ReceiveAttack(int DMG)
	{
		_HP -= DMG;
		if (_HP <= 0)
			Destroy(gameObject);
	}

	public void LaunchAttack(Entity OtherEntity)
	{
		OtherEntity.ReceiveAttack(this.DMG);
	}


	public void DestroyEntity()
	{

		Destroy(gameObject);
	}
}
