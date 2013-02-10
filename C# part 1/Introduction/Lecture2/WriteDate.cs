/*
 * Author: Tsvetomir Nikolov
 * Student number: 6001771
 * Email: cvetomir.nikolov@gmail.com
 * 
 */
using System;

namespace WriteDate
{
	class WriteDate
	{
		static void Main()
		{
			const string dateFormat = "dd MMMM yyyy";
			string date = DateTime.Now.ToString(dateFormat);
			Console.WriteLine(date);
		}
	}
}
