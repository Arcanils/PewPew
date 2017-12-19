using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {


	public PawnComponent Pawn;
	public Vector2 VecDir;

	public void FixedUpdate()
	{
		if (Pawn != null)
			Pawn.Move(VecDir * Time.fixedDeltaTime);
	}

}
