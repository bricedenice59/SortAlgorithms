namespace SortAlgorithms
{
    internal class BubbleSort
    {
        public void Sort<T>(T[] items) where T : IComparable
        {
            if (items.Count() > 0 && items[0].GetType() != typeof(int))
                throw new NotImplementedException($"type {typeof(T)} has not yet been implemented");

            for (int i = 0; i < items.Length -1; i++)
            {
                for (int j = 0; j < items.Length - (i+1); j++)
                {
                    if(items[j].CompareTo(items[j + 1]) >0)
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
