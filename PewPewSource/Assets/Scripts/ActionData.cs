using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAction
{
	IEnumerator ActionOverTime(Transform Target);
}

public class ActionMove : IAction
{
	public Vector2 VecMove;
	public float Duration;
	

	private Transform _trans;
	private Vector3 _origine;
	private Vector3 _currentOffset;
	private static WaitForFixedUpdate _waitFixed = new WaitForFixedUpdate();

	private void Init(Transform Target)
	{
		_trans = Target;
		_origine = _trans.position;
		_currentOffset = Vector3.zero;
	}

	public IEnumerator ActionOverTime(Transform Target)
	{
		for (float t = 0f, perc = 0f; perc < 1f; t += Time.fixedDeltaTime)
		{
			perc = Mathf.Clamp01(t / Duration);
			_currentOffset.x = VecMove.x * perc;
			_currentOffset.y = VecMove.y * perc;
			_trans.position = _origine + _currentOffset;
			yield return _waitFixed;
		}
	}
}

public class ActionSpawn
{
	public GameObject PrefabSpawn;
	public Vector3[] OffsetSpawn;
	public int NSpawn;
}

public class ActionSelfDestruct
{

}

public class ActionWait
{

}
