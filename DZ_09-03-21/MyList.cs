using System;

namespace DZ_09_03_21
{
	class MyList<T>
	{
		T[] arr;
		public int Count
		{
			get
			{
				return arr.Length;
			}
		}
		public MyList()
		{
			this.arr = new T[0];
		}
		public MyList(params T[] itemsToAdd)
		{
			this.arr = new T[itemsToAdd.Length];
			for (int i = 0; i < this.arr.Length; i++)
			{
				this.arr[i] = itemsToAdd[i];
			}
		}
		public int RemoveAt(int iToRemove)
		{
			if (this.arr.Length <= iToRemove)
			{
				throw new IndexOutOfRangeException();
			}
			T[] newArr = new T[this.arr.Length - 1];
			for (int i = 0; i < this.arr.Length - 1; i++)
			{
				if (i >= iToRemove)
				{
					newArr[i] = this.arr[i + 1];
				}
				else
				{
					newArr[i] = this.arr[i];
				}
			}
			this.arr = newArr;
			return this.arr.Length;
		}
		public T this[int index]
		{
			get
			{
				if (this.arr.Length <= index)
				{
					throw new IndexOutOfRangeException();
				}
				return this.arr[index];
			}
			set
			{
				if (this.arr.Length <= index)
				{
					throw new IndexOutOfRangeException();
				}
				this.arr[index] = value;
			}
		}
		public T Get(int iToGet)
		{
			if (this.arr.Length <= iToGet)
			{
				throw new IndexOutOfRangeException();
			}
			return this.arr[iToGet];
		}
		public int Add(T itemToAdd)
		{
			T[] temp = new T[this.arr.Length + 1];
			for (int i = 0; i < this.arr.Length; i++)
			{
				temp[i] = this.arr[i];
			}
			temp[arr.Length] = itemToAdd;
			this.arr = temp;
			return this.arr.Length;
		}
		public int AddRange(params T[] itemsToAdd)
		{
			T[] temp = new T[this.arr.Length + itemsToAdd.Length];
			for (int i = 0; i < temp.Length; i++)
			{
				if (i < this.arr.Length)
				{
					temp[i] = this.arr[i];
				}
				else
				{
					temp[i] = itemsToAdd[i - this.arr.Length];
				}

			}
			this.arr = temp;
			return this.arr.Length;
		}
		public int AddRange(MyList<T> lst)
		{
			T[] temp = new T[this.arr.Length + lst.Count];
			for (int i = 0; i < temp.Length; i++)
			{
				if (i < this.arr.Length)
				{
					temp[i] = this.arr[i];
				}
				else
				{
					temp[i] = lst[i - this.arr.Length];
				}

			}
			this.arr = temp;
			return this.arr.Length;
		}
		public void Show()
		{
			foreach (var item in this.arr)
			{
				System.Console.WriteLine(item);
			}
		}

	}
}
