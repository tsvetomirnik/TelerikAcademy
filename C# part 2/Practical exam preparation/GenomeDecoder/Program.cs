using System;
using System.Collections.Generic;
using System.Text;

namespace GenomeDecoder
{
	internal class Program
	{
		private static void Main()
		{
			string info = Console.ReadLine();

			int maxGenomLength = int.Parse(info.Substring(0, info.IndexOf(" ", StringComparison.Ordinal)));
			info = info.Remove(0, info.IndexOf(" ", StringComparison.Ordinal));
			int maxGenomPart = int.Parse(info.Substring(info.IndexOf(" ", StringComparison.Ordinal), info.Length));

			string genomeSequence = Console.ReadLine();

			var numbers = new List<int>();
			var numberBuilder = new StringBuilder();
			for (int i = 0; i < genomeSequence.Length; i++)
			{
				if (char.IsDigit(genomeSequence[i]))
				{
					numberBuilder.Append(genomeSequence[i]);
				}
				else
				{
					if (numberBuilder.Length == 0)
					{
						numbers.Add(1);
					}
					else if (numberBuilder.Length > 0)
					{
						numbers.Add(int.Parse(numberBuilder.ToString()));
						numberBuilder.Clear();
					}
				}
			}

			var values = new List<char>();
			for (int i = 0; i < genomeSequence.Length; i++)
			{
				if (char.IsLetter(genomeSequence[i]))
				{
					values.Add(genomeSequence[i]);
				}
			}

			var overalGenom = new StringBuilder();
			for (int i = 0; i < values.Count; i++)
			{
				overalGenom.Append(new string(values[i], numbers[i]));
			}

			double rowsCount = Math.Ceiling(overalGenom.Length/(double) maxGenomLength);
			for (int i = 0; i < rowsCount; i++)
			{
				Console.Write((i + 1).ToString().PadLeft(rowsCount.ToString().Length));
				for (int j = 0; j < maxGenomLength; j++)
				{
					if ((j)%maxGenomPart == 0)
					{
						Console.Write(" ");
					}

					if (j + (i*maxGenomLength) > overalGenom.Length - 1)
					{
						break;
					}

					Console.Write(overalGenom[j + (i*maxGenomLength)]);
				}

				Console.WriteLine();
			}
		}
	}
}