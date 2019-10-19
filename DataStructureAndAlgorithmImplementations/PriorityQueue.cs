using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgorithmImplementations
{
    /// <summary>
    /// A min priority queus implementation in C#. Thisimplementation tracks each element in the binary heap with a hashtabel for quick insertions and removals
    /// </summary>
    /// <typeparam name="T"></typeparam>
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

        /// <summary>
        /// Constructs a priority queue using heapify in O(n) time
        /// 
        /// Heapify is the process of converting a binary tree into a Heap data structure. 
        /// A binary tree being a tree data structure where each node has at most two child nodes.
        /// A Heap must be a complete binary tree, that is each level of the tree is completely filled, except possibly the bottom level. 
        /// At this level, it is filled from left to right.
        /// A Heap must also satisfy the heap-order property, the value stored at each node is greater than or equal to it’s children.
        /// </summary>
        /// <param name="elements"></param>
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

        /// <summary>
        /// Priority queue construction O(nlog(n))
        /// </summary>
        /// <param name="elements"></param>
        public PriorityQueue(ICollection<T> elements):this(elements.Count)
        {
            foreach (var element in elements)
            {
                Add(element);
            }
        }

        /// <summary>
        /// Returns true or false dependig on if the priority queue is empty
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Returns the size of the heap
        /// </summary>
        /// <returns></returns>
         public int Size()
        {
            return HeapSize;
        }


        /// <summary>
        /// Clears everything inside the heap, O(n)
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < HeapCapacity; i++)
            {
                Heap[i] = null;
            }
            HeapSize = 0;
        }

        /// <summary>
        /// Returns the element with the lowest priority in the priority queue
        /// Returns null iof the priority queue is empty
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            if (IsEmpty())
                return null;
            else
                return Heap[0];
        }

        /// <summary>
        /// Removes the root of the heap,O(log(n))
        /// </summary>
        /// <returns></returns>
        public T Poll() => RemoveAt(0);

        public bool Contains(T elem)
        {
            for (int i = 0; i < HeapSize; i++)
            {
                bool isEqual = Heap[i].Equals(elem);
                if (isEqual)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Adds element to the priority queue, element must not be null
        /// Timecomplexity of O(log(n))
        /// </summary>
        /// <param name="element"></param>
        private void Add(T element)
        {
            if (element == null)
                throw new ArgumentNullException();

            if(HeapSize<HeapCapacity)
            {
                Heap[HeapSize] = element;
            }
            else
            {
                Heap.Add(element);
                ++HeapCapacity;
            }

            Swim();
            ++HeapSize;
        }

        /// <summary>
        /// Tests if the value of node i <= node j
        /// assumeing i & j are valid indices, O(1)</summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private IsLess(int i, int j)
        {
            T node1 = Heap[i];
            T node2 = Heap[j];

            return node1.CompareTo(node2);
        }

        /// <summary>
        /// Perform bottom up node swim, O(log(n))
        /// </summary>
        /// <param name="k"></param>
        private void Swim(int k)
        {
            // Grab the index of the next parent node in relation to k
            int parent = (k - 1) / 2;

            //Keep swimming as long as we have not reached the root and while we're less than our parent
            while(k>0 && less(k, parent))
            {
                //exchange node at k with node at parent position
                Swap(parent, k);
                k = parent;

                // Grab the index of the next parent node in relation to k

                parent = (k - 1) / 2;
            }
        }

        /// <summary>
        /// Top down node sink O(log(n))
        /// </summary>
        private void Sink(int k)
        {
            while (true)
            {
                int left = 2 * k - 1;
                int right = 2 * k - 2;

                //assumes the left node is the smallest
                int smallest = left;

                //Find if the left or right is the smaller node
                // If right is smaller set smallest to left
                if (right < HeapSize && IsLess(right, left))
                    smallest = right;

                //Stop if we're outside the bounds of the binary heap
                //Or stop when we cannot sink k anymore
                if (left >= HeapSize || IsLess(k, smallest))
                    break;

                Swap(smallest, k);
                k = smallest;
            }
        }

        public void MapAdd(T element, int index)
        {

        }


        public void Sink(int i)
        {

        }

    }
}
