using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	public Vector3 Speed = new Vector3(100, 0f, 0f);
	public float DeathTime = 2;

	public IAction[] ActionToDo;
	private Transform _trans;

	public void Awake()
	{
		_trans = transform;
		Destroy(gameObject, DeathTime);
	}

	public void Start()
	{
		var Duration = 0.5f;
		var a1 = new ActionMove();
		a1.Duration = Duration;
		a1.VecMove = new Vector2(0f, 1f);
		var a2 = new ActionMove();
		a2.Duration = Duration;
		a2.VecMove = new Vector2(1f, 0f);
		var a3 = new ActionMove();
		a3.Duration = Duration * 2;
		a3.VecMove = new Vector2(0f, -2f);
		var a4 = new ActionMove();
		a4.Duration = Duration;
		a4.VecMove = new Vector2(1f, 0f);
		var a5 = new ActionMove();
		a5.Duration = Duration;
		a5.VecMove = new Vector2(0f, 1f);
		ActionToDo = new IAction[] { a1, a2, a3, a4, a5 };
		StartCoroutine(LogicAction());
	}

	public IEnumerator LogicAction()
	{
		while (true)
		{
			for (int i = 0; i < ActionToDo.Length; i++)
			{
				var routine = ActionToDo[i].ActionOverTime(_trans);
				while (routine.MoveNext())
					yield return new WaitForFixedUpdate();
			}
		}
	}
	/*
	private void FixedUpdate()
	{
		_trans.position += Speed * Time.fixedDeltaTime;
	}
	*/
}
