
namespace AssetsPattern
{
	[System.Serializable]
	public class GenericReference<T, S> where S : GenericVariable<T> where T : struct
	{
		public bool UseConstant = true;
		public T ConstantValue;
		public S Variable;

		public GenericReference()
		{ }

		public GenericReference(T value)
		{
			UseConstant = true;
			ConstantValue = value;
		}

		public T Value
		{
			get
			{
				return UseConstant ? ConstantValue : Variable.Value;
			}
			set
			{
				if (UseConstant)
					ConstantValue = value;
				else
					Variable.Value = value;
			}
		}
	}
}