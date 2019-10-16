using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgorithmImplementations
{
    public class PriorityQueue<T>
        where T: IComparable
    {

        int HeapSize { get; set; } = 0;
        int HeapCapacity { get; set; } = 0;

        IList<T> Heap { get; set; } = new List<T>();
        Dictionary<T, SortedSet<int>> Map { get; set; } = new Dictionary<T, SortedSet<int>>();

        public PriorityQueue():this(1)
        {
        }

        public PriorityQueue(int capacity)
        {
            HeapCapacity = capacity;
        }

        public PriorityQueue(T[] elements)
        {
            HeapSize = HeapCapacity = elements.Length;

            Heap = new List<T>(HeapCapacity);

            for (int i = 0; i < elements.Length; i++)
            {
                MapAdd(elements[i], i);
                Heap.Add(elements[i]);
            }

            //Heapify Process O(n)
            for (int i = Math.Max(0,(HeapSize/2)-1); i >=0; i--)
            {
                Sink(i);
            }

        }

        public PriorityQueue(ICollection<T> elements):this(elements.Count)
        {
            foreach (var element in elements)
            {
                Add(element);
            }
        }


        public bool IsEmpty()
        {
            return HeapSize == 0;
        }

        public void Clear()
        {
            for (int i = 0; i < HeapCapacity; i++)
            {
                Heap[i] = default(T);
            }
            HeapSize = 0;
            Map.Clear();
        }

         public int Size()
        {
            return HeapSize;
        }

        private void Add(T element)
        {
            throw new NotImplementedException();
        }

        public void MapAdd(T element, int index)
        {

        }


        public void Sink(int i)
        {

        }

    }
}
