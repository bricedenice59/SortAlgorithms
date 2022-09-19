namespace SortAlgorithms
{
    internal class BubbleSort<T> : IComparer<T>
    {
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

            var comparer = Comparer<T>.Create(Compare);

            for (int i = 0; i < items.Length -1; i++)
            {
                for (int j = 0; j < items.Length - (i+1); j++)
                {
                    if(comparer.Compare(items[j], items[j + 1]) >0)
                    {
                        var tmp = items[j + 1];
                        items[j + 1] = items[j];
                        items[j] = tmp;
                    }
                }
            }
        }
    }
}
