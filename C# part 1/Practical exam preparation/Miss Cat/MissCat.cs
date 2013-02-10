/*
 * Author: Tsvetomir Nikolov
 * Email: cvetomir.nikolov@gmail.com
 * Task: Miss Cat
 * BGCoder result: 100%
 */

using System;

namespace Miss_Cat
{
	class MissCat
	{
		static void Main()
		{
			uint catsPlayers = uint.Parse(Console.ReadLine());
			int[] votes = new int[10];

			for (int i = 0; i < catsPlayers; i++)
			{
				byte catNumber = byte.Parse(Console.ReadLine());
				votes[catNumber - 1]++;
			}

			int maxVotesCatIndex = 0;
			for (int i = 0; i < votes.Length; i++)
			{
				if(votes[i] > votes[maxVotesCatIndex])
				{
					maxVotesCatIndex = i;
				}
			}

			Console.WriteLine(maxVotesCatIndex + 1);
		}
	}
}
