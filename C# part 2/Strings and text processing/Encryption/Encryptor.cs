using System;

namespace Encryption
{
	internal class Encryptor
	{
		public string Encrypt(string value, string key)
		{
			if (string.IsNullOrEmpty(value.Trim()))
			{
				throw new ArgumentException("Invalid argument content.", "value");
			}

			if (string.IsNullOrEmpty(key.Trim()))
			{
				throw new ArgumentException("Invalid argument content.", "key");
			}

			if (key.Length < value.Length)
			{
				key = GetFullKey(key, value.Length);
			}

			var encryptedChars = new char[value.Length];
			for (int i = 0; i < value.Length; i++)
			{
				encryptedChars[i] = (char) (value[i] ^ key[i]);
			}

			return new string(encryptedChars);
		}

		public string Decrypt(string value, string key)
		{
			return Encrypt(value, key);
		}

		private static string GetFullKey(string key, int desiredSize)
		{
			if (key.Length >= desiredSize)
			{
				return key;
			}

			char[] keyArray = key.ToCharArray();
			Array.Resize(ref keyArray, desiredSize);
			for (int i = key.Length; i < desiredSize; i++)
			{
				keyArray[i] = keyArray[i - key.Length];
			}

			key = new string(keyArray);
			return key;
		}
	}
}