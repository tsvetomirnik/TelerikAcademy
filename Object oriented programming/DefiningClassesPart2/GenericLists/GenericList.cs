using System;
using System.Linq;
using System.Text;

namespace GenericLists
{
	/// <summary>
	/// Initialize new instance of GelenericList class to work with collection of elements
	/// </summary>
	class GenericList<T>
	{
		protected const byte CapacityStep = 4;
		private T[] elements;
		private int currentElementIndex;
		private int capacity;

		public GenericList(int capacity)
		{
			currentElementIndex = 0;
			Capacity = capacity;
			elements = new T[Capacity];
		}

		/// <summary>
		/// Get current capacity size
		/// </summary>
		public int Capacity
		{
			get { return capacity; }
			private set
			{
				if(value < 0)
				{
					throw new ArgumentException("Negative numbers are not allowed as a capacity value.");
				}

				capacity = value;
			}
		}

		/// <summary>
		/// Get collection element by index
		/// </summary>
		public T this [int index]
		{
			get 
			{ 
				if (index < 0 || index > currentElementIndex-1)
                {
					throw new ArgumentException("Invalid index");
                }

				return elements[index];
			}
			set
			{
				if (index < 0 || index > currentElementIndex-1)
                {
					throw new ArgumentException("Invalid index");
                }

				RemoveAt(index);
				InsertAt(index, value);
			}
		}

		/// <summary>
		/// Returns the position of specific element or -1 if the element is not found
		/// </summary>
		public int GetPosition(T obj)
		{
			if(obj is Nullable && obj == null)
			{
				throw new ArgumentNullException();
			}

			int position = -1;
			for (int i = 0; i < currentElementIndex; i++)
			{
				if(elements[i].Equals(obj))
				{
					position = i;
					break;
				}
			}

			return position;
		}

		/// <summary>
		/// Insert new element on the end of elements collection
		/// </summary>
		public void Add(T obj)
		{
			InsertAt(currentElementIndex, obj);
		}

		/// <summary>
		/// Insert new element at specific position
		/// </summary>
		public void InsertAt(int position, T obj)
		{
			if(obj is Nullable && obj == null)
			{
				throw new ArgumentNullException();
			}

			if(position < 0 || position > currentElementIndex)
			{
				throw new ArgumentOutOfRangeException();
			}

			if(currentElementIndex > 0 && currentElementIndex % CapacityStep == 0)
			{
				ЕxpandArray();
			}

			int rightValuesCount = currentElementIndex - position;
			if(rightValuesCount > 0)
			{
				var rightValues = new T[rightValuesCount];
				Array.Copy(elements, position, rightValues, 0, rightValuesCount);
				elements[position] = obj;
				Array.Copy(rightValues, 0, elements, position+1, rightValuesCount);
			}
			else
			{
				//Add to last place
				elements[currentElementIndex] = obj;
			}

			currentElementIndex++;
		}
  
		/// <summary>
		/// Exapnd the array capacity 
		/// </summary>
		protected void ЕxpandArray()
		{
			int newCapacity = elements.Count() + CapacityStep;
			Array.Resize(ref elements, elements.Count() -1 + CapacityStep);
			Capacity = newCapacity;
		}

		/// <summary>
		/// Remove existing element at specific position
		/// </summary>
		public void RemoveAt(int position)
		{
			if(position < 0 || position > currentElementIndex)
			{
				throw new ArgumentOutOfRangeException();
			}

			int rightValuesCount = currentElementIndex - position;
			if(rightValuesCount > 0)
			{
				Array.Copy(elements, position-1, elements, position, rightValuesCount);
			}
			else
			{
				Clear();
			}

			currentElementIndex--;
		}

		/// <summary>
		/// Clear all elements from current instance
		/// </summary>
		public void Clear()
		{
			elements = new T[CapacityStep];
		}

		/// <summary>
		/// Get current elements number
		/// </summary>
		public int Count
		{
			get { return currentElementIndex; }
		}

		/// <summary>
		/// Returns the min element in the current collection
		/// </summary>
		public T Min()
		{
			return elements.Min();
		}

		/// <summary>
		/// Returns the biggest element in the current collection
		/// </summary>
        public T Max()
		{
			return elements.Max();
		}

		/// <summary>
		/// Returns a string representation of current object
		/// </summary>
		public override string ToString()
		{
			var result = new StringBuilder();
			result.Append("[");

			for (int i=0; i < currentElementIndex; i++)
			{
				result.Append(elements[i]);

				if(i < currentElementIndex-1)
				{
					result.Append(", ");
				}
			}

			result.Append("]");

			return result.ToString();
		}
	}
}
