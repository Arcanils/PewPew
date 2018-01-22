using AssetsPattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
	public int IndexPlayer = -1;
	public GameEvent GE_OnDeath;

	private Vector2 vecDir;
	private string _inputNameMoveX;
	private string _inputNameMoveY;


	public override void Init(ControllerComponentConfig Config)
	{
		base.Init(Config);
		_inputNameMoveX = IndexPlayer >= 0 ? "Horizontal_" + IndexPlayer : "Horizontal";
		_inputNameMoveY = IndexPlayer >= 0 ? "Vertical_" + IndexPlayer : "Vertical";
	}
	public override void TickAI(float DeltaTime)
	{
		vecDir.x = Input.GetAxis(_inputNameMoveX);
		vecDir.y = Input.GetAxis(_inputNameMoveY);
		if (vecDir != Vector2.zero)
			vecDir = vecDir.normalized * vecDir.magnitude;
		_refPawn.Move(vecDir.x, vecDir.y, DeltaTime);
		/*
		if (Input.GetButtonDown("SwitchAmmo"))
			_refPawn.SwitchAmmo();
			*/
	}

	public override void ResetAfterDisable()
	{
		base.ResetAfterDisable();
		if (GE_OnDeath != null)
			GE_OnDeath.Raise();
	}
}
