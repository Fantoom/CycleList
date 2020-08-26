using System;

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
		///	Returns element by index and sets currentIndex to index
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

		private int GetIndex(int index)
		{
			return index - index / this.Count * this.Count;
		}
	}
}
