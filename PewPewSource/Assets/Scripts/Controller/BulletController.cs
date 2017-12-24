using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : BaseController
{

	public Vector3 Speed = new Vector3(100, 0f, 0f);
	public float DeathTime = 2;
	public ActionBehaviourScriptable BehaviourData;
	public bool IsDisable { get; private set; }

	//public IAction[] ActionToDo;

	private IEnumerator _currentRoutine;
	private int _currentIndexAction;

	public override void Init()
	{
		base.Init();
		_currentIndexAction = -1;
		IsDisable = BehaviourData.Actions.Length == 0;
	}

	public void Start()
	{/*
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
		ActionToDo = new IAction[] { a1, a2, a3, a4, a5 };*/
		//StartCoroutine(LogicAction());
	}

	public override void TickFixed()
	{
		do
		{
			SetNextAction();
		} while (!_currentRoutine.MoveNext());
	}

	private void SetNextAction()
	{
		_currentIndexAction = (_currentIndexAction + 1) % BehaviourData.Actions.Length;
		_currentRoutine = BehaviourData.Actions[_currentIndexAction].GetData().ActionOverTime(_refPawn);
	}

	public IEnumerator LogicAction()
	{
		do
		{
			for (int i = 0; i < BehaviourData.Actions.Length; i++)
			{
				var routine = BehaviourData.Actions[i].GetData().ActionOverTime(_refPawn);
				while (routine.MoveNext())
					yield return new WaitForFixedUpdate();
			}
		} while (BehaviourData.Repeat);
	}
	
}
