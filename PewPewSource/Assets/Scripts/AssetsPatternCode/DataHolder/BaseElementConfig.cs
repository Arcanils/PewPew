using AssetsPattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseElementConfig : ScriptableObject {

#if UNITY_EDITOR
	[Multiline]
	public string DeveloperDescription = "";
#endif

	public PoolObjectComponent Controller;
	public PoolObjectComponent Pawn;
	public FloatReference HP;
}
