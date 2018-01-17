using AssetsPattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : BaseController
{
	public GameEvent[] EventsOnDeath;
	public IntVariable Score;
	public int ScoreOnDeath;
	
	public Vector2 VecDir;
	

	public override void TickAI(float DeltaTime)
	{
		if (_refPawn != null)
			_refPawn.Move(VecDir * DeltaTime);
	}

	public override void ResetAfterDisable()
	{
		base.ResetAfterDisable();
		Score.Value += ScoreOnDeath;
		if (EventsOnDeath != null)
		{
			for (int i = EventsOnDeath.Length - 1; i >= 0; --i)
			{
				if (EventsOnDeath[i] != null)
					EventsOnDeath[i].Raise();
			}
		}
	}
}
