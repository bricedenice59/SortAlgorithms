using System.ComponentModel;
using System.Xml.Linq;

namespace SortAlgorithms
{
    //At a given index i of an array: Index of parent node for an element at i: (i - 1)/2
    //Left Child index for an element at i : (2* i + 1)
    //Right Child index for an element at i : (2* i + 2)
    internal class HeapSort<T> where T : IComparable<T>
    {
        private readonly List<T> _items;

        public List<T> Items => _items;
        public HeapSort()
        {
            _items = new List<T>();
        }

        public void Sort(IEnumerable<T> items)
        {
            if (!items.Any())
                throw new Exception("List of items is empty!");

            foreach (var item in items)
            {
                Insert(item);
            }

            int deletedElements = 0;
            while (deletedElements <= _items.Count -1)
            {
                T root = _items[0];
                var indexItemToRemove = _items.Count - 1 - deletedElements;

                _items[0] = _items[indexItemToRemove];
                _items[indexItemToRemove] = root;

                deletedElements++;
                SinkDown(_items.Count - deletedElements);
            }
        }
        
        public void SortWithHeapify(IEnumerable<T> items)
        {
            var itemList = items.ToList();
            if (!itemList.Any())
                throw new Exception("List of items is empty!");
     
            var itemsCount = itemList.Count;
            
            for (var i = (itemsCount / 2) - 1; i >= 0; i--)
            {
                Heapify(itemList, itemsCount, i);
            }

            for (var i = itemsCount - 1; i >= 0; i--)
            {
                Swap(itemList, itemList[0], 0, i);
                Heapify(itemList, i, 0);
            }
        }

        public int GetHeapHeight(IEnumerable<T> items)
        {
            var nbNodes = items.Count();
            var height = 0;

            //heap height = [2^(h+1) -1]
            while (((int)Math.Pow(2, height +1) - 1) < nbNodes)
            {
                height++;
            }
            return height;
        }

        private void Insert(T item)
        {
            if (_items.Count == 0)
            {
                _items.Add(item);
                return; 
            }
            _items.Add(item);

            BuildMaxHeap();
        }

        /// <summary>
        /// Swap values from the list of items without introducing another temporary variable, so that I keep O(1) storage complexity
        /// </summary>
        /// <param name="items"></param>
        /// <param name="element"></param>
        /// <param name="currentIndex"></param>
        /// <param name="newIndex"></param>
        private void Swap(List<T> items, T element, int currentIndex, int newIndex)
        {
            items[currentIndex] = _items[newIndex];
            items[newIndex] = element;
        }

        /// <summary>
        /// That function sinks a value down until the heap is rebuild.
        /// Conditions for the heap to be rebuilt and to be valid are: the parent value must always be greater than its children and the final built tree is a complete tree)
        /// </summary>
        private void SinkDown(int maxIndex)
        {
            int currentIndex = 0;
            int swapIndex = -1;
            T valueAtCurrentIndex = _items[currentIndex];
            
            while (true)
            {
                bool swapRequired = false;
                //from explanations here above 
                var leftChildIndex = (2 * currentIndex) +1;
                var rightChildIndex= (2 * currentIndex) + 2;

                T leftChildValueAtIndex = default;
                if (leftChildIndex < maxIndex)
                {
                    // Compare the node to bubble down with left child, if > then a swap is required
                    leftChildValueAtIndex = _items[leftChildIndex];
                    if (leftChildValueAtIndex.CompareTo(valueAtCurrentIndex) >0)
                    {
                        swapRequired = true;
                        swapIndex = leftChildIndex;
                    }
                }
                
                if (rightChildIndex < maxIndex)
                {
                    //here the condition is slightly harder to understand as a swap may already be required from previous condition
                    //but the value from the right node may be > than the value of the left node, so we must be careful what leaf index we need to swap the current value with
                    var rightChildValueAtIndex = _items[rightChildIndex];
                    if ((!swapRequired && rightChildValueAtIndex.CompareTo(valueAtCurrentIndex) >0) 
                        || (swapRequired && rightChildValueAtIndex.CompareTo(leftChildValueAtIndex) >0))
                    {
                        swapRequired = true;
                        swapIndex = rightChildIndex;
                    }
                }
                
                if(!swapRequired)
                    break;
                
                Swap(_items, valueAtCurrentIndex, currentIndex, swapIndex);
                currentIndex = swapIndex;
            }
        }
        
        private void Heapify(List<T> items, int size, int maxIndex)
        {
            var largestIndex = maxIndex;
            var leftChildIndex = (2 * maxIndex) +1;
            var rightChildIndex= (2 * maxIndex) + 2;
            
            var rightChildValueAtIndex = items[rightChildIndex];
            var leftChildValueAtIndex = items[leftChildIndex];
            var largestItemValueAtIndex = items[largestIndex];
            
            if (leftChildIndex < size && leftChildValueAtIndex.CompareTo(largestItemValueAtIndex) >0)
            {
                largestIndex = leftChildIndex;
            }

            if (rightChildIndex < size && rightChildValueAtIndex.CompareTo(largestItemValueAtIndex) >0)
            {
                largestIndex = rightChildIndex;
            }

            //largest must not be the root
            if (largestIndex != maxIndex)
            {
                Swap(items, largestItemValueAtIndex, largestIndex, maxIndex);
                Heapify(items, size, largestIndex);
            }
        }

        private void BuildMaxHeap()
        {
            int currentItemIndex = _items.Count - 1;
            T currentElement = _items.ElementAt(currentItemIndex);
            //explanations here above 
            int parentIndex = (currentItemIndex - 1) / 2;

            while (parentIndex >= 0 && currentElement.CompareTo(_items[parentIndex]) > 0)
            {
                //swap child with its parent
                Swap(_items, currentElement, currentItemIndex, parentIndex);

                //reset indexes
                currentItemIndex = parentIndex;
                parentIndex = (currentItemIndex - 1) / 2;
            }
        }
    }
}
