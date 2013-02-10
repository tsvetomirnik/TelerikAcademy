/* Task 18: Write a program for extracting all email addresses from given text.
 * All substrings that match the format <identifier>@<host>…<domain> should be
 * recognized as emails.
 */

using System;
using System.Collections.Generic;

namespace ExtractEmails
{
	internal class Program
	{
		private static void Main()
		{
			string content = "For more information contect info@gmail.com anytime.";
			IEnumerable<string> emails = GetAllEmails(content);

			foreach (string email in emails)
			{
				Console.WriteLine(email);
			}
		}

		private static IEnumerable<string> GetAllEmails(string content)
		{
			var emails = new List<string>();
			int indexOfAtSign;
			do
			{
				indexOfAtSign = content.IndexOf("@", StringComparison.Ordinal);

				if (indexOfAtSign != -1)
				{
					string emailCandidate = GetAtSignLiteral(content, indexOfAtSign);
					if (IsEmail(emailCandidate))
					{
						emails.Add(emailCandidate);
					}
					content = content.Remove(indexOfAtSign, 1);
				}
			} while (indexOfAtSign != -1);

			return emails;
		}

		private static string GetAtSignLiteral(string content, int atIndex)
		{
			if (atIndex < 0)
			{
				return string.Empty;
			}

			string identifier = content.Substring(0, atIndex);
			int blankSpaceIndex = identifier.LastIndexOf(' ');
			if (blankSpaceIndex != -1)
			{
				identifier = identifier.Substring(blankSpaceIndex + 1);
			}

			string host = content.Substring(atIndex);
			blankSpaceIndex = host.IndexOf(' ');
			if (blankSpaceIndex != -1)
			{
				host = host.Substring(0, blankSpaceIndex);
			}

			return identifier + host;
		}

		private static bool IsEmail(string emailAdress)
		{
			emailAdress = emailAdress.Trim();

			//Check the symbols
			foreach (char c in emailAdress)
			{
				if (!char.IsLetterOrDigit(c) && !char.IsPunctuation(c) && c != '@')
				{
					return false;
				}
			}

			//Check is there only one '@' symbol
			if (emailAdress.IndexOf("@", StringComparison.Ordinal)
			    != emailAdress.LastIndexOf("@", StringComparison.Ordinal))
			{
				return false;
			}

			//Check does it have identifier
			if (emailAdress.IndexOf("@", StringComparison.Ordinal) <= 0)
			{
				return false;
			}

			string afterIdentifier = emailAdress.Substring(emailAdress.IndexOf("@", StringComparison.Ordinal) + 1);

			//Check is there only one '.' symbol
			if (afterIdentifier.IndexOf(".", StringComparison.Ordinal)
			    != afterIdentifier.LastIndexOf(".", StringComparison.Ordinal))
			{
				return false;
			}

			//Check the host
			if (afterIdentifier.IndexOf('.') <= 0)
			{
				return false;
			}

			//Check the domain
			int lastPointIndex = afterIdentifier.LastIndexOf('.');
			if (lastPointIndex == -1 || lastPointIndex == afterIdentifier.Length - 1)
			{
				return false;
			}

			return true;
		}
	}
}