/*
 * Author: Tsvetomir Nikolov
 * Student number: 6001771
 * Email: cvetomir.nikolov@gmail.com
 * 
 * Task 14: A bank account has a holder name (first name, middle name and last name),
 * available amount of money (balance), bank nassociated with the account. Declare the
 * variables needed to keep ame, IBAN, BIC code and 3 credit card numbers the information
 * for a single bank account using the appropriate data types and descriptive names.
 * 
 */


using System.Collections.Generic;
using System.Text;

namespace BankAccount
{
	class BankAccount
	{
		public class Account
		{
			public string FirstName { get; set; }
			public string MiddleName { get; set; }
			public string LastName { get; set; }
			public string FullName
			{
				get
				{
					var fullName = new StringBuilder();
					if (!string.IsNullOrEmpty(FirstName))
						fullName.Append(FirstName);
					if (!string.IsNullOrEmpty(MiddleName))
						fullName.Append(string.Format(" {0}", MiddleName));
					if (!string.IsNullOrEmpty(LastName))
						fullName.Append(string.Format(" {0}", LastName));

					return fullName.ToString();
				}
			}
			public string BankName { get; set; }
			public string IBAN { get; set; }
			public string BIC { get; set; }
			public List<string> CreditCardNumber;

			public Account()
			{
				CreditCardNumber = new List<string>(3);
			}
		}

		static void Main()
		{
			var accout = new Account
			{
				FirstName = "Ivan",
				MiddleName = "Ivanov",
				LastName = "Ivanov",
				BankName = "Obedinena Bylgarska Banka",
				BIC = "UBBSBGSF",
				IBAN = "GB29 NWBK 6016 1331 9268 19",
			};

			accout.CreditCardNumber.Add("378282246310005");
		}
	}
}
