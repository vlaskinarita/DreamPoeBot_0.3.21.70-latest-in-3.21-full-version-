using System;
using System.Collections;
using System.Collections.Generic;
using DreamPoeBot.Common;

namespace DreamPoeBot.Loki.Common;

public static class Algorithms
{
	public class MaximalRectangle
	{
		private readonly int int_0;

		private readonly BitArray bitArray_0;

		private readonly int int_1;

		public MaximalRectangle(BitArray matrix, int width, int height)
		{
			bitArray_0 = matrix.Clone() as BitArray;
			int_1 = width;
			int_0 = height;
		}

		private bool method_0(int int_2, int int_3)
		{
			if (int_2 >= 0 && int_3 >= 0 && int_2 < int_1)
			{
				return int_3 < int_0;
			}
			return false;
		}

		private int method_1(int int_2, int int_3)
		{
			return int_3 * int_1 + int_2;
		}

		public IEnumerable<Tuple<Vector2i, Vector2i>> FindMaximalRectanglesGreedy()
		{
			Vector2i vector2i = new Vector2i(0, 0);
			Vector2i rs = new Vector2i(int_1 - 1, int_0 - 1);
			int num = System.Math.Min(rs.X, rs.Y);
			while (vector2i != rs)
			{
				if (method_0(vector2i.X, vector2i.Y) && bitArray_0[method_1(vector2i.X, vector2i.Y)])
				{
					for (int i = 0; i < num; i++)
					{
						Vector2i vector2i3 = new Vector2i(vector2i.X + i, vector2i.Y + i);
						if (!method_2(vector2i, vector2i3))
						{
							continue;
						}
						vector2i3 = new Vector2i(vector2i3.X - 1, vector2i3.Y - 1);
						yield return new Tuple<Vector2i, Vector2i>(vector2i, vector2i3);
						for (int j = 0; j < System.Math.Abs(vector2i.X - vector2i3.X); j++)
						{
							for (int k = 0; k < System.Math.Abs(vector2i.Y - vector2i3.Y); k++)
							{
								int index = method_1(vector2i.X + j, vector2i.Y + k);
								try
								{
									bitArray_0[index] = false;
								}
								catch (Exception)
								{
								}
							}
						}
						break;
					}
				}
				vector2i.X++;
				if (vector2i.X > rs.X)
				{
					vector2i.X = 0;
					vector2i.Y++;
				}
			}
		}

		private bool method_2(Vector2i vector2i_0, Vector2i vector2i_1)
		{
			int num = System.Math.Abs(vector2i_0.X - vector2i_1.X);
			int num2 = System.Math.Abs(vector2i_0.Y - vector2i_1.Y);
			int num3 = num - 1;
			while (num3 >= 0)
			{
				if (method_0(vector2i_1.X - num3, vector2i_1.Y) && bitArray_0[method_1(vector2i_1.X - num3, vector2i_1.Y)])
				{
					num3--;
					continue;
				}
				return false;
			}
			int num4 = num2 - 1;
			while (true)
			{
				if (num4 >= 0)
				{
					if (!method_0(vector2i_1.X, vector2i_1.Y - num4) || !bitArray_0[method_1(vector2i_1.X, vector2i_1.Y - num4)])
					{
						break;
					}
					num4--;
					continue;
				}
				return true;
			}
			return false;
		}
	}
}
