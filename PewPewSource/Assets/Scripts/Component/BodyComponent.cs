using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssetsPattern;

[System.Serializable]
public class BodyComponent : MonoBehaviour
{
	public FloatReference CurrentHP;

	private BodyComponentConfig _config;

	public void Init(BodyComponentConfig Config)
	{
		_config = Config;
		CurrentHP.Value = _config.HP.Value;
	}

	public void OnCollisionEnter2D(Collision2D collision)
	{
		if (!_config.CanDamage)
			return;

		var OtherEntity = collision.gameObject.GetComponent<BodyComponent>();

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

	public void LaunchAttack(BodyComponent OtherEntity)
	{
		OtherEntity.ReceiveAttack(this._config.Damage);
	}


	public void DestroyEntity()
	{

		Destroy(gameObject);
	}
}
