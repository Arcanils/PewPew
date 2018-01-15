using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractController : MonoBehaviour
{

	protected PawnComponent _refPawn;
	protected PoolObjectComponent _poolObjectComponent;
	protected ControllerComponentConfig _config;

	public abstract void Awake();

	public abstract void TickFixed();

	public abstract void Init(ControllerComponentConfig Config);
	public abstract void ResetAfterDisable();
	public abstract void Destroy();

	public abstract void SetPawn(PawnComponent Pawn);
}
