/* Task 7: Write a program that encodes and decodes a string using given
 * encryption key (cipher). The key consists of a sequence of characters.
 * The encoding/decoding is done by performing XOR (exclusive or) operation
 * over the first letter of the string with the first of the key, the second
 * – with the second, etc. When the last key character is reached, the next 
 * is the first.
 */

using System;

namespace Encryption
{
	internal class Program
	{
		private static void Main()
		{
			var encryptor = new Encryptor();
			const string key = "dog";
			const string value = "password";
			string encrypted = encryptor.Encrypt("password", key);
			string decrypted = encryptor.Decrypt(encrypted, key);

			Console.WriteLine("Encrypted value \"{0}\" by key \"{1}\" is \"{2}\".", value, key, encrypted);
			Console.WriteLine("Decrypted value \"{0}\" by key \"{1}\" is \"{2}\".", encrypted, key, decrypted);
		}
	}
}