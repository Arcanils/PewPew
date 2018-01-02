using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssetsPattern;

[System.Serializable]
public class BodyComponent : MonoBehaviour
{
	public System.Action OnDeath;
	public FloatReference CurrentHP;
	private BodyComponentConfig _config;
	private bool _deadOne;

	public void Init(BodyComponentConfig Config)
	{
		_config = Config;
		CurrentHP.Value = _config.HP.Value;
		_deadOne = false;
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

		RaiseDeathEvent();
	}

	public void ReceiveAttack(int DMG)
	{
		CurrentHP.Value -= DMG;
		if (CurrentHP.Value <= 0)
		{
			RaiseDeathEvent();
		}
	}

	public void LaunchAttack(BodyComponent OtherEntity)
	{
		OtherEntity.ReceiveAttack(this._config.Damage);
	}

	public void RaiseDeathEvent()
	{
		if (!_deadOne && OnDeath != null)
		{
			OnDeath();
			_deadOne = true;
		}
	}
}
