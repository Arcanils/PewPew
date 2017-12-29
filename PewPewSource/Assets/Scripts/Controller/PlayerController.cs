using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{

	private Vector2 vecDir;
	

	public override void TickFixed()
	{
		vecDir.x = Input.GetAxis("Horizontal");
		vecDir.y = Input.GetAxis("Vertical");
		_refPawn.Move(vecDir * Time.fixedDeltaTime);
		/*
		if (Input.GetButtonDown("SwitchAmmo"))
			_refPawn.SwitchAmmo();
			*/
	}
}
