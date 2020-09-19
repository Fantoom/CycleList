using System;
using System.Linq;

namespace System.Collections.Generic
{
	public class CycleList<T> : List<T> , IList<T>
	{
		private int currentIndex = -1;
		public int CurrentIndex 
		{
			get => currentIndex; 
			set 
			{
				if (value > 0)
					currentIndex = GetIndex(value);
				else Reset(); 
			}
		}

		/// <summary>
		///	Returns or sets element by index and sets currentIndex to passed index
		/// </summary>
		public new T this[int index] 
		{
			get 
			{
				currentIndex = index;
				return base[GetIndex(index)]; 
			} 
			set 
			{
				base[GetIndex(index)] = value;
			}
		}
		/// <summary>
		///	Returns next element
		/// </summary>
		public T GetNext()
		{
			currentIndex = GetIndex(currentIndex + 1);
			return this[currentIndex];
		}

		/// <summary>
		///	Sets currentIndex to -1
		/// </summary>
		public void Reset()
		{
			currentIndex = -1;
		}
		/// <summary>
		///	Clears array and Resets it
		/// </summary>
		public new void Clear()
		{
			Reset();
			base.Clear();
		}
		/// <summary>
		///	Removes item at index, and decreases currentIndex by 1
		/// </summary>
		public new void RemoveAt(int index)
		{
			var i = GetIndex(index);
			base.RemoveAt(i);
			if (currentIndex == i && currentIndex > -1)
				currentIndex--;	
		}
		/// <summary>
		///	Inserts item at index, and decreases currentIndex by 1
		/// </summary>
		public new void Insert(int index, T item)
		{
			var i = GetIndex(index);
			base.Insert(i, item);
			if (currentIndex == i && currentIndex > -1)
				currentIndex--;
		}

		private int GetIndex(int index)
		{
			if (Count > 0)
				return index % Count;
			else
				return index;
		}
	}
	public static class CycleListExtenstion
	{
		public static T GetCycled<T>(this IEnumerable<T> enumerable, int index)
		{
			if (enumerable is List<T>)
			{
				var list = enumerable as List<T>;
				return list[index % list.Count];
			}
			else
			{
				var list = enumerable.ToList();
				return list[index % list.Count];
			}
		}
	}
}
