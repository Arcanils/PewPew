using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class IAction
{
	public abstract IEnumerator ActionOverTime(PawnComponent Pawn);
}

[System.Serializable]
public class ActionMove : IAction
{
	public Vector2 VecMove;
	public float Duration;

	private static WaitForFixedUpdate _waitFixed = new WaitForFixedUpdate();
	
	public override IEnumerator ActionOverTime(PawnComponent Pawn)
	{
		Vector3 _origine = Pawn.GetPosition();
		Vector3 _currentOffset = Vector3.zero;
		for (float t = 0f, perc = 0f; perc < 1f; t += Time.fixedDeltaTime)
		{
			perc = Mathf.Clamp01(t / Duration);
			_currentOffset.x = VecMove.x * perc;
			_currentOffset.y = VecMove.y * perc;
			Pawn.SetPosition(_origine + _currentOffset);
			yield return _waitFixed;
		}
	}
}


[System.Serializable]
public class ActionSpawn : IAction
{
	public GameObject PrefabSpawn;
	public Vector3[] OffsetSpawn;
	public Vector3[] RotationSpawn;
	public int NSpawn;

	public override IEnumerator ActionOverTime(PawnComponent Pawn)
	{
		for (int i = 0; i < NSpawn; i++)
		{
			Spawn(PrefabSpawn, OffsetSpawn[i % OffsetSpawn.Length] + Pawn.GetPosition(), RotationSpawn[i % RotationSpawn.Length]);
		}
		yield break;
	}

	private static void Spawn(GameObject Prefab, Vector3 Position, Vector3 EulerRotation)
	{
		var instance = GameObject.Instantiate<GameObject>(Prefab, Position, Quaternion.identity);
		var pawn = instance.GetComponent<PawnComponent>();
		if (pawn != null)
			pawn.SetDirection(EulerRotation);
	}
}

[System.Serializable]
public class ActionWait : IAction
{
	float Duration;

	public override IEnumerator ActionOverTime(PawnComponent Pawn)
	{
		yield return new WaitForSeconds(Duration);
	}
}

[System.Serializable]
public class ActionMoveCurve : IAction
{
	public AnimationCurve[] Curves;
	public float Duration;
	public Vector2 VecMove;

	public override IEnumerator ActionOverTime(PawnComponent Pawn)
	{
		yield break;
	}
}

[System.Serializable]
public class ActionSelfDestruct : IAction
{

	public override IEnumerator ActionOverTime(PawnComponent Pawn)
	{
		Pawn.SelfDestroy();
		yield break;
	}
}
