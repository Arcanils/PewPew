using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssetsPattern;

[System.Serializable]
public class Entity : MonoBehaviour
{
	public IntReference MaxHP;
	public IntReference CurrentHP;

	public IntReference DMG;
	public Vector2Reference TESTTT;
	public bool ApplyDMG;

	public IntReference Score;


	public void Init()
	{
		CurrentHP.Value = MaxHP.Value;
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
		CurrentHP.Value -= DMG;
		if (CurrentHP.Value <= 0)
			Destroy(gameObject);
	}

	public void LaunchAttack(Entity OtherEntity)
	{
		OtherEntity.ReceiveAttack(this.DMG.Value);
	}


	public void DestroyEntity()
	{

		Destroy(gameObject);
	}
}
