using SortAlgorithms.Utils;

namespace SortAlgorithms
{
    internal class QuickSort
    {
        public void Sort<T>(T[] items) where T: IComparable
        {
            if (items.Count() > 0 && items[0].GetType() != typeof(int))
                throw new NotImplementedException($"type {typeof(T)} has not yet been implemented");

            Sort(items, 0, items.Length -1);
        }

        private T[] Sort<T>(T[] items, int left, int right) where T : IComparable
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

        private int Partition<T>(T[] items, int left, int right) where T : IComparable
        {
            var pivot = items[left];
            var i = left;
            var j = right;

            while(i<=j)
            {
                while (items[i].CompareTo(pivot) < 0)
                {
                    i++;
                }
                while (items[j].CompareTo(pivot) > 0)
                {
                    j--;
                }
                if (i >= j) break;
                Swap(items, i, j);
            }
            return j;
        }

        private void Swap<T>(T[] items, int first, int second)
        {
            var tmp = items[first];
            items[first] = items[second];
            items[second] = tmp;
        }
    }
}
