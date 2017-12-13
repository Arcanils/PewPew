using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public PawnComponent Pawn;

	private Vector2 vecDir;

	public void FixedUpdate()
	{
		vecDir.x = Input.GetAxis("Horizontal");
		vecDir.y = Input.GetAxis("Vertical");
		Pawn.Move(vecDir * Time.fixedDeltaTime);
	}


}
