using System;
using System.Linq;

namespace ega_lab3;

public static class BreadthHillClimbingMethod
{
	public static (BinaryCoding, int) FindSolution(SearchDomain domain, uint iterationCount)
	{
		var bestCoding = domain.PickRandom();
		var bestFitness = domain.CalculateFitness(bestCoding);

		var neighbourhood = new Neighbourhood(bestCoding);
		var neighbours = neighbourhood.GetSequentially().ToList();

		for (var i = 0; i < iterationCount; i++)
		{
			Console.WriteLine($"\nИтерация №{i+1}  |  Лучшая кодировка: {bestCoding} ({bestFitness})");
			Console.WriteLine("> Соседи лучшей кодировки:");
			foreach (var neighbour in neighbours)
			{
				Console.WriteLine($"> {neighbour} ({domain.CalculateFitness(neighbour)})");
			}

			var word = FindBestNeighbour(domain, neighbourhood);
			var fitness = domain.CalculateFitness(word);
			Console.WriteLine($">\n> Отобранный кандидат: {word} ({fitness})");

			if (fitness > bestFitness)
			{
				bestFitness = fitness;
				bestCoding = word;

				neighbourhood = new Neighbourhood(bestCoding);
				neighbours = neighbourhood.GetSequentially().ToList();

				Console.WriteLine("> (!) Рассматриваемая приспособленность лучше имеющейся, обновляем");
			}
			else
			{
				Console.WriteLine("> Рассматриваемая приспособленность не лучше имеющейся, пропускаем");
				break;
			}
		}

		return (bestCoding, bestFitness);
	}

	private static BinaryCoding FindBestNeighbour(SearchDomain domain, Neighbourhood neighbourhood) =>
		neighbourhood.GetSequentially().MaxBy(domain.CalculateFitness) ?? throw new InvalidOperationException();
}
