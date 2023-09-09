internal sealed class Class37
{
	internal static uint smethod_0(string string_0)
	{
		uint num = 0u;
		if (string_0 != null)
		{
			num = 2166136261u;
			for (int i = 0; i < string_0.Length; i++)
			{
				num = (string_0[i] ^ num) * 16777619;
			}
		}
		return num;
	}
}
