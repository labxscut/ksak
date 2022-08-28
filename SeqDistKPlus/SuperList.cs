using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeqDistKPlus
{
    public class SuperList<T> : IList<T> where T : IEquatable<T>
    {
        private T defaultValue;
        private IDictionary<long, int> indexMap = new Dictionary<long, int>();
        private IList<T> values = new List<T>();
        private IDictionary<T, int> valueIndices = new Dictionary<T, int>();
        private long count;

        private IList<T> normalList = new List<T>();
        private bool useSuperPower;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="count">initial count</param>
        /// <param name="useSuperPower">false: normal mode, use normal list(same as List<T>); true: super mode, use super list</param>
        public SuperList(long count = 0, bool useSuperPower = true)
        {
            this.count = count;
            this.useSuperPower = Settings.useSuperList;
            if (!this.useSuperPower)
            {
                normalList = new List<T>((int)count);
                for (int i = 0; i < count; i++)
                    normalList.Add(defaultValue);
            }
        }

        /// <summary>
        /// indexer
        /// </summary>
        /// <param name="index">index</param>
        /// <returns>indexted value or default (not found)</returns>
        public T this[int index]
        {
            get
            {
                if (!useSuperPower)
                    return normalList[index];
                // 如果查询到则返回值；查不到就返回默认值
                if (indexMap.TryGetValue(index, out int valueIndex))
                {
                    return values[valueIndex];
                }
                else
                {
                    return defaultValue;
                }
            }
            set
            {
                if (!useSuperPower)
                {
                    normalList[index] = value; return;
                }
                if (this[index].Equals(value)) return;
                if (defaultValue.Equals(value))
                {
                    if (indexMap.ContainsKey(index))
                    {
                        indexMap.Remove(index);
                    }
                }
                else
                {
                    if (valueIndices.TryGetValue(value, out int valueIndex))
                    {
                        indexMap[index] = valueIndex;
                    }
                    else
                    {
                        values.Add(value);
                        valueIndices[value] = values.Count - 1;
                        indexMap[index] = values.Count - 1;
                    }
                }
            }
        }

        /// <summary>
        /// super indexer (only for super mode)
        /// </summary>
        /// <param name="index">long index</param>
        /// <returns></returns>
        public T this[long index]
        {
            get
            {
                if (!useSuperPower)
                {
                    return normalList[(int)index];
                }
                // 如果查询到则返回值；查不到就返回默认值
                if (indexMap.TryGetValue(index, out int valueIndex))
                {
                    return values[valueIndex];
                }
                else
                {
                    return defaultValue;
                }
            }
            set
            {
                if (!useSuperPower)
                {
                    normalList[(int)index] = value; return;
                }
                if (this[index].Equals(value)) return;
                if (defaultValue.Equals(value))
                {
                    if (indexMap.ContainsKey(index))
                    {
                        indexMap.Remove(index);
                    }
                }
                else
                {
                    if (valueIndices.TryGetValue(value, out int valueIndex))
                    {
                        indexMap[index] = valueIndex;
                    }
                    else
                    {
                        values.Add(value);
                        valueIndices[value] = values.Count - 1;
                        indexMap[index] = values.Count - 1;
                    }
                }
            }
        }

        public int Count => (int)count;
        public long LongCount => count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            this[count] = item;
            count++;
        }

        public void Clear()
        {
            defaultValue = Activator.CreateInstance<T>();
            indexMap.Clear();
            values.Clear();
            valueIndices.Clear();
            count = 0;
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
