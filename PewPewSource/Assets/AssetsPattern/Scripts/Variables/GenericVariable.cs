using UnityEngine;

namespace AssetsPattern
{
	[System.Serializable]
	public class GenericVariable<T> : ScriptableObject where T : struct
	{
#if UNITY_EDITOR
		[Multiline]
		public string DeveloperDescription = "";
#endif
		[SerializeField]
		public T Value;

		public void SetValue(T value)
		{
			Value = value;
		}

		public void SetValue(GenericVariable<T> value)
		{
			Value = value.Value;
		}
	}
}
