using System;
using System.Collections.Generic;

namespace GridSystem.Pathfinding
{
	internal class SimplePriorityQueue<T> where T : IComparable<T>
    {
        private readonly List<T> heap = new List<T>();

        public int Count => heap.Count;

        public void Enqueue(T item)
        {
            heap.Add(item);
            HeapifyUp(heap.Count - 1);
        }

        public T Dequeue()
        {
            if (heap.Count == 0)
                throw new InvalidOperationException("Queue is empty");

            T root = heap[0];
            heap[0] = heap[^1];
            heap.RemoveAt(heap.Count - 1);

            if (heap.Count > 0)
                HeapifyDown(0);
            
            return root;
        }

        public void UpdatePriority(T item)
        {
            int index = heap.IndexOf(item);
            if (index == -1)
                throw new InvalidOperationException("Item not found in queue");

            HeapifyUp(index);
            HeapifyDown(index);
        }

        public T Peek()
        {
            if (heap.Count == 0)
                throw new InvalidOperationException("Queue is empty");

            return heap[0];
        }

        public bool Contains(T item) => heap.Contains(item);

        private void HeapifyUp(int index)
        {
            while (index > 0)
            {
                int parentIndex = (index - 1) / 2;
                if (heap[index].CompareTo(heap[parentIndex]) >= 0)
                    break;

                Swap(index, parentIndex);
                index = parentIndex;
            }
        }

        private void HeapifyDown(int index)
        {
            int count = heap.Count;
            while (true)
            {
                int smallest = index;
                int leftChild = 2 * index + 1;
                int rightChild = 2 * index + 2;

                if (leftChild < count && heap[leftChild].CompareTo(heap[smallest]) < 0)
                    smallest = leftChild;
                if (rightChild < count && heap[rightChild].CompareTo(heap[smallest]) < 0)
                    smallest = rightChild;
                if (smallest == index)
                    break;

                Swap(index, smallest);
                index = smallest;
            }
        }

        private void Swap(int i, int j)
        {
            T temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }
    }
}