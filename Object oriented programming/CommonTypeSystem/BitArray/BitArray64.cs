using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitArray
{
	class BitArray64 : IEnumerable<int>
	{
		public const int UlongBites = 63;

		public ulong Value { get; set; }

		public BitArray64() 
			: this(0)
		{
		}

		public BitArray64(ulong value) 
		{
			Value = value;
		}

		public int this[int index] 
		{
			get 
			{
				if (index < 0 || index > UlongBites) 
				{
					throw new ArgumentOutOfRangeException("Index values must be in range between " + " 0 and " + UlongBites + ".");
				}

				return (int)((this.Value >> index) & 1);
			}
		}

		public override bool Equals(object obj)
		{
			var bitArray = obj as BitArray64;
			if (bitArray == null)
			{
				return false;
			}

			if (!Object.Equals(this.Value, bitArray.Value))
			{
				return false;
			}

			return true;
		}

		public static bool operator ==(BitArray64 array1, BitArray64 array2)
		{
			return BitArray64.Equals(array1, array2);
		}

		public static bool operator !=(BitArray64 array1, BitArray64 array2)
		{
			return (!BitArray64.Equals(array1, array2));
		}
		
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		public IEnumerator GetEnumerator()
		{
			return this.GetEnumerator();
		}

		IEnumerator<int> IEnumerable<int>.GetEnumerator()
		{
			for (int i = UlongBites; i >= 0; i--)
			{
				yield return this[i];
			}
		}

		public override string ToString()
		{
			var result = new StringBuilder();

			for (int i = UlongBites; i >= 0; i--)
			{
				result.Append(this[i]);
			}

			return result.ToString();
		}
	}
}