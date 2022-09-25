using System;

namespace ega_lab3;

public sealed class SearchDomain
{
	private int WordLength { get; }
	private readonly IFitnessCalculator<BinaryCoding, int> _fitnessCalculator;
	private readonly int _maxValue;

	public SearchDomain(int wordLength)
	{
		WordLength = wordLength;
		_fitnessCalculator = new ArbitraryFitnessCalculator();
		_maxValue = Convert.ToInt32(Math.Pow(2, WordLength)) - 1;
	}

	public BinaryCoding PickRandom()
	{
		return new BinaryCoding(Utilities.GetRandom(_maxValue), WordLength);
	}

	public int CalculateFitness(BinaryCoding word)
	{
		return _fitnessCalculator.Calculate(word);
	}
}
