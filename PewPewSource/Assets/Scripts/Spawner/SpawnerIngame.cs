using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerIngame : MonoBehaviour
{
	private SpawnParcoursLvl _data;
	
	public void InitLvl()
	{

	}
	/*
	private IEnumerator LoadGameplayEnum()
	{
		var SpawnDatas = _data.ListActionLvl;
		for (int i = 0, iLength = SpawnDatas.Length; i < iLength; ++i)
		{
			// Spawn SpawnDatas[i]
		}
	}
	*/
}

public class SpawnParcoursLvl : ScriptableObject
{
#if UNITY_EDITOR
	public string DescriptionDev;
#endif
	public SpawnParcoursPart[] ListActionLvl;
}

public class SpawnParcoursPart
{
	public SpawnPart Part;
	public SpawnParcoursPart Next;
}

public class SpawnPart : ScriptableObject
{
#if UNITY_EDITOR
	public string DescriptionDev;
#endif
	public SpawnAction[] ListAction;

	public IEnumerator[] GetFctSpawn()
	{
		return null;
	}
	public IEnumerator[] GetFctValidation()
	{
		return null;
	}
}

public class SpawnAction
{
	public EntityConfig EntityToSpawn;
	//Config Override
	public Vector3 PositionSpawn;
	public int NSpawn;
	public float DelayBetweenSpawn;
	public float DelayBeforeValidation;
	public bool ConditionAfterEmpty;

	public SpawnAction()
	{
		//EntityToSpawn = new EntityConfig(); OverrideConfig
	}

	public virtual IEnumerator SpawnLogic(EntityFactory Factory)
	{
		GameObject instance = null;
		float time = 0f;
		for (int i = 0; i < NSpawn; i++)
		{
			instance = Factory.GetNewEntity(EntityToSpawn, PositionSpawn);
		
			for (time = 0f; time < DelayBetweenSpawn; time += Time.deltaTime)
			{
				yield return null;
			}
		}
	}

	public virtual IEnumerator WaitConditionValidation()
	{
		if (ConditionAfterEmpty && NSpawn > 0)
		{
			for (float time = 0f, duration = DelayBetweenSpawn * NSpawn; time < duration; time += Time.deltaTime)
			{
				yield return null;
			}
		}

		if (DelayBeforeValidation > 0f)
		{
			for (float time = 0f; time < DelayBeforeValidation; time += Time.deltaTime)
			{
				yield return null;
			}
		}
	}
}
