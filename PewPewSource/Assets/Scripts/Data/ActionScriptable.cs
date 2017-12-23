using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IActionScriptable : ScriptableObject
{

	public virtual IAction GetData()
	{
		return null;
	}
}

[CreateAssetMenu(fileName = "Move", menuName = "Action/Move", order = 1)]
public class ActionMoveScriptable : IActionScriptable
{
	public ActionMove Action;

	public override IAction GetData()
	{
		return Action;
	}
}
[CreateAssetMenu(fileName = "Wait", menuName = "Action/Wait", order = 1)]
public class ActionWaitScriptable : IActionScriptable
{
	public ActionWait Action;
	public override IAction GetData()
	{
		return Action;
	}
}
[CreateAssetMenu(fileName = "MoveCurve", menuName = "Action/MoveCurve", order = 1)]
public class ActionMoveCurveScriptable : IActionScriptable
{
	public ActionMoveCurve Action;
	public override IAction GetData()
	{
		return Action;
	}
}

[CreateAssetMenu(fileName = "SelfDestru", menuName = "Action/SelfDestru", order = 1)]
public class ActionSelfDestrucriptable : IActionScriptable
{
	public ActionSelfDestruct Action;
	public override IAction GetData()
	{
		return Action;
	}
}

[CreateAssetMenu(fileName = "Spawn", menuName = "Action/Spawn", order = 1)]
public class ActionSpawnScriptable : IActionScriptable
{
	public ActionSpawn Action;
	public override IAction GetData()
	{
		return Action;
	}
}

[CreateAssetMenu(fileName = "Behaviour", menuName = "Action/Behaviour", order = 1)]
public class ActionBehaviourScriptable : ScriptableObject
{
	public IActionScriptable[] Actions;
	public bool Repeat;
}
