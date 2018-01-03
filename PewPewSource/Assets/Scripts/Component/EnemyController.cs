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
	

	public override void TickFixed()
	{
		if (_refPawn != null)
			_refPawn.Move(VecDir * Time.fixedDeltaTime);
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
