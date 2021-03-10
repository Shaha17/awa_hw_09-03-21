using System.Globalization;
using System.ComponentModel;
using System;

namespace DZ_09_03_21
{
	class Program
	{
		static void Main(string[] args)
		{
			MyList<int> lst = new MyList<int>();
			lst.AddRange(1, 2, 3, 4, 45, 6, 6);
			lst.Show();


			System.Console.WriteLine();

			MyDictionary<int, string> dict = new MyDictionary<int, string>();
			dict.Add(1, "1");
			dict.Add(2, "2");
			dict.Add(3, "3");
			dict.Add(4, "4");
			dict.Show();
		}
	}
	class MyDictionary<TKey, TValue>
	{
		TValue[] values;
		TKey[] keys;

		public int Count
		{
			get
			{
				return values.Length;
			}
		}
		public MyDictionary()
		{
			this.keys = new TKey[0];
			this.values = new TValue[0];
		}
		public int RemoveAt(TKey toRemove)
		{
			int iToRm = -1;
			for (int i = 0; i < this.keys.Length; i++)
			{
				if (this.keys[i].Equals(toRemove))
				{
					iToRm = i;
				}
			}
			if (iToRm == -1)
			{
				throw new IndexOutOfRangeException();
			}
			TValue[] newValues = new TValue[this.values.Length - 1];
			TKey[] newKeys = new TKey[this.keys.Length - 1];
			for (int i = 0; i < this.keys.Length - 1; i++)
			{
				if (i >= iToRm)
				{
					newValues[i] = this.values[i + 1];
					newKeys[i] = this.keys[i + 1];
				}
				else
				{
					newValues[i] = this.values[i];
					newKeys[i] = this.keys[i];
				}
			}
			this.keys = newKeys;
			this.values = newValues;
			return this.keys.Length;
		}
		public TValue this[TKey key]
		{
			get
			{
				int iToGet = -1;
				for (int i = 0; i < this.keys.Length; i++)
				{
					if (this.keys[i].Equals(key))
					{
						iToGet = i;
					}
				}
				if (iToGet >= this.keys.Length)
				{
					throw new IndexOutOfRangeException();
				}
				return this.values[iToGet];
			}
			set
			{
				int iToSet = -1;
				for (int i = 0; i < this.keys.Length; i++)
				{
					if (this.keys[i].Equals(key))
					{
						iToSet = i;
					}
				}
				if (iToSet >= this.keys.Length)
				{
					throw new IndexOutOfRangeException();
				}
				this.values[iToSet] = value;
			}
		}
		public TValue Get(TKey key)
		{
			int iToGet = -1;
			for (int i = 0; i < this.keys.Length; i++)
			{
				if (this.keys[i].Equals(key))
				{
					iToGet = i;
				}
			}
			if (iToGet == -1)
			{
				throw new IndexOutOfRangeException();
			}
			return this.values[iToGet];
		}
		public int Add(TKey key, TValue value)
		{
			bool hasThisKey = false;
			for (int i = 0; i < this.keys.Length; i++)
			{
				if (this.keys[i].Equals(key))
				{
					hasThisKey = true;
				}
			}
			if (hasThisKey)
			{
				throw new Exception("Попытка добавить существующий ключ");
			}
			TValue[] newValues = new TValue[this.values.Length + 1];
			TKey[] newKeys = new TKey[this.keys.Length + 1];
			for (int i = 0; i < this.keys.Length; i++)
			{
				newValues[i] = this.values[i];
				newKeys[i] = this.keys[i];
			}
			newValues[newValues.Length - 1] = value;
			newKeys[newKeys.Length - 1] = key;
			this.keys = newKeys;
			this.values = newValues;
			return this.keys.Length;
		}
		public void Show()
		{
			foreach (var item in this.values)
			{
				System.Console.WriteLine(item);
			}
		}
	}
}
