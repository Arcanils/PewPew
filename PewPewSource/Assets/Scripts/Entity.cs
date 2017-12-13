using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
	public int HP;
	public int DMG;
	public bool ApplyDMG;

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
		HP -= DMG;
		if (HP <= 0)
			Destroy(gameObject);
	}

	public void LaunchAttack(Entity OtherEntity)
	{
		OtherEntity.ReceiveAttack(this.DMG);
	}

}
