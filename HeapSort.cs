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

        //public void Sort(List<T> items) 
        //{
        //}

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

        public void Insert(T item)
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
        /// Delete the root item from the heap
        /// </summary>
        /// <returns>Returns the root element deleted</returns>
        /// <exception cref="Exception"></exception>
        public T Delete()
        {
            if (_items.Count == 0)
                throw new Exception("List of items is empty!");

            T root = _items[0];

            _items[0] = _items[_items.Count -1];
            _items.RemoveAt(_items.Count -1);

            Heapify();

            return root;
        }

        private void Swap(List<T> items, T element, int currentIndex, int newIndex)
        {
            items[currentIndex] = _items.ElementAt(newIndex);
            items[newIndex] = element;
        }

        /// <summary>
        /// That function sinks a value down until the heap is rebuild.
        /// Conditions for the heap to be rebuilt and to be valid are: the parent value must always be greater than its children and the final built tree is a complete tree)
        /// </summary>
        private void Heapify()
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
                if (leftChildIndex < _items.Count)
                {
                    // Compare the node to bubble down with left child, if > then a swap is required
                    leftChildValueAtIndex = _items[leftChildIndex];
                    if (leftChildValueAtIndex.CompareTo(valueAtCurrentIndex) >0)
                    {
                        swapRequired = true;
                        swapIndex = leftChildIndex;
                    }
                }
                
                if (rightChildIndex < _items.Count)
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

        private void BuildMaxHeap()
        {
            int currentItemIndex = _items.Count - 1;
            T currentElement = _items.ElementAt(currentItemIndex);
            //explanations here above 
            int parentIndex = (currentItemIndex - 1) / 2;

            while (parentIndex >= 0 && _items.ElementAt(currentItemIndex).CompareTo(_items.ElementAt(parentIndex)) > 0)
            {
                //swap child with its parent
                Swap(_items, currentElement, currentItemIndex, parentIndex);
                // _items[currentItemIndex] = _items.ElementAt(parentIndex);
                // _items[parentIndex] = currentElement;

                //reset indexes
                currentItemIndex = parentIndex;
                parentIndex = (currentItemIndex - 1) / 2;
            }
        }
    }
}
