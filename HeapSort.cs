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

        private void BuildMaxHeap()
        {
            int currentItemIndex = _items.Count - 1;
            T currentElement = _items.ElementAt(currentItemIndex);
            //explanations here above 
            int parentIndex = (currentItemIndex - 1) / 2;

            while (parentIndex >= 0 && _items.ElementAt(currentItemIndex).CompareTo(_items.ElementAt(parentIndex)) > 0)
            {
                //swap child with its parent
                _items[currentItemIndex] = _items.ElementAt(parentIndex);
                _items[parentIndex] = currentElement;

                //reset indexes
                currentItemIndex = parentIndex;
                parentIndex = (currentItemIndex - 1) / 2;
            }
        }
    }
}
