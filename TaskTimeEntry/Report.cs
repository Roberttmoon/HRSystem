using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTimeEntry
{
    public class Report<T> : IEnumerable<T>
    {
        public T[] items = null;
        int freeIndex = 0;

        public Report()
        {
            items = new T[10];
        }

        public void AddItem(T item)
        {
            items[freeIndex] = item;
            freeIndex += 1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach(T item in items)
            {
                if (item == null) break;
                yield return item;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
