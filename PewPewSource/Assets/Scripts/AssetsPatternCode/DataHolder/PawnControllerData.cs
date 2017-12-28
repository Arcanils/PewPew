﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PawnControllerData : ScriptableObject
{
#if UNITY_EDITOR
	[Multiline]
	public string DeveloperDescription = "";
#endif

	public BaseController Controller;
	public PawnComponent Pawn;
	
}
