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
	private float _timeImmortal;
	private bool _isMortal;
	private bool _isInvicibleByConfig;

	public void Init(BodyComponentConfig Config)
	{
		_config = Config;
		_isInvicibleByConfig = _config.IsImmortal;
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

	public void ReceiveAttack(float DMG)
	{
		if (_isMortal)
		{
			CurrentHP.Value -= DMG;
			if (CurrentHP.Value <= 0)
			{
				RaiseDeathEvent();
			}
			else if (_config.DurationImmortal > 0f)
			{
				_isMortal = false;
				_timeImmortal = _config.DurationImmortal;
			}
		}
	}

	public void Tick(float DeltaTime)
	{
		if (!_isInvicibleByConfig && !_isMortal)
		{
			_timeImmortal += DeltaTime;
			if (_timeImmortal >= 0f)
			{
				_isMortal = true;
			}
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
