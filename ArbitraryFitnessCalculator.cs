using System;
using static System.Math;

namespace ega_lab3;

public sealed class ArbitraryFitnessCalculator: IFitnessCalculator<BinaryCoding, int>
{
	public int Calculate(BinaryCoding preimage)
	{
		var value = preimage.Value - Convert.ToInt32(Pow(2, preimage.Length - 1));
		return Convert.ToInt32(Pow(value, 2));
	}
}
