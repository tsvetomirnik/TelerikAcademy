using System;

namespace Task5
{
	class Task5
	{
		public static int AScorePaths;
		public static int BScorePaths;

		static void Main()
		{
			const int playersInTeam = 8;

			//Fill A team
			var aPlayers = new int[playersInTeam];
			for (int i = 0; i < playersInTeam; i++)
			{
				aPlayers[i] = int.Parse(Console.ReadLine());
			}

			//Fill B team
			var bPlayers = new int[playersInTeam];
			for (int i = 0; i < playersInTeam; i++)
			{
				bPlayers[i] = int.Parse(Console.ReadLine());
			}

			//Clear players at same position
			for (int i = 0; i < playersInTeam; i++)
			{
				int samePosPlayers = aPlayers[i] & bPlayers[i];
				aPlayers[i] = aPlayers[i] & (~samePosPlayers);
				bPlayers[i] = bPlayers[i] & (~samePosPlayers);
			}

			//Get team A scores
			int aScores = 0;
			for (int i = 0; i < playersInTeam; i++)
			{
				int aPlayer = aPlayers[i];
				int bPlayersPos = 0;

				//Gets all players positions, bottom from the current player, by vertical lines
				for (int j = i; j < playersInTeam ; j++)
				{
					bPlayersPos = bPlayersPos | bPlayers[j];
				}

				//If the line where the player can score is empty check the AScorePaths
				int playerScores = aPlayer ^ bPlayersPos;
				int aScore = aPlayer & playerScores;
				aScores += GetPlayerAScore(aScore);
			}

			//Get team B scores
			int bScores = 0;
			for (int i = 0; i < playersInTeam; i++)
			{
			    int bPlayer = bPlayers[i];
			    int aPlayersPos = 0;

				//Gets all players positions, top from the current player, by vertical lines
			    for (int j = i; j >= 0 ; j--)
			    {
			        aPlayersPos = aPlayersPos | aPlayers[j];
			    }

				//If the line where the player can score is empty check the BScorePaths
			    int playerScores = bPlayer ^ aPlayersPos;
			    int bScore = bPlayer & playerScores;
			    bScores += GetPlayerBScore(bScore);
			}

			Console.WriteLine("{0}:{1}", aScores, bScores);
		}

		/// <summary>
		/// Shows is player from A team score depending if in the same line already has a score
		/// </summary>
		private static int GetPlayerAScore(int input)
		{
			int score = AScorePaths ^ input;
			AScorePaths = AScorePaths | input;
			return GetScoreFromBinaryNumber(score & input);
		}

		/// <summary>
		/// Shows is player from B team score depending if in the same line already has a score
		/// </summary>
		private static int GetPlayerBScore(int input)
		{
			int score = BScorePaths ^ input;
			BScorePaths = BScorePaths | input;
			return GetScoreFromBinaryNumber(score & input);
		}

		/// <summary>
		/// Count '1' in a decimal representation of a number
		/// </summary>
		private static int GetScoreFromBinaryNumber(int input)
		{
			int score = 0;
			string binaryScore = Convert.ToString(input, 2);
			foreach (char s in binaryScore)
			{
				if(s.ToString() == "1")
				{
					score++;
				}
			}

			return score;
		}
	}
}
