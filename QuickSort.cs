namespace SortAlgorithms
{
    internal class QuickSort<T> : IComparer<T>
    {
        private Comparer<T> _comparer;
        public int Compare(T? x, T? y)
        {
            if (x == null)
                return 0;
            if (y == null)
                return 0;

            if (int.Parse(x.ToString()) > int.Parse(y.ToString()))
                return 1;
            if (int.Parse(x.ToString()) < int.Parse(y.ToString()))
                return -1;

            return 0;
        }

        public void Sort(T[] items)
        {
            if (items.Count() > 0 && items[0].GetType() != typeof(int))
                throw new NotImplementedException($"type {typeof(T)} has not yet been implemented");

            _comparer = Comparer<T>.Create(Compare);

            Sort(items, 0, items.Length -1);
        }

        private T[] Sort(T[] items, int left, int right)
        {
            if (left < right)
            {
                int partition = Partition(items, left, right);
                if(partition >1)
                    Sort(items, left, partition);
                if(partition+1 < right)
                    Sort(items, partition + 1, right);
            }
            return items;
        }

        private int Partition(T[] items, int left, int right)
        {
            var pivot = items[left];
            var i = left;
            var j = right;

            while(i<=j)
            {
                while (_comparer.Compare(items[i], pivot) < 0)
                {
                    i++;
                }
                while (_comparer.Compare(items[j], pivot) > 0)
                {
                    j--;
                }
                if (i >= j) break;
                Swap(items, i, j);
            }
            return j;
        }

        private void Swap(T[] items, int first, int second)
        {
            var tmp = items[first];
            items[first] = items[second];
            items[second] = tmp;
        }
    }
}
