using SortAlgorithms;
using SortAlgorithms.Utils;
using System.Security.Cryptography;

int maxArrayLength = (int)1e7;
int[] array = new int[maxArrayLength];

for (int i = 0; i < maxArrayLength; i++)
{
    array[i] = RandomNumberGenerator.GetInt32(1, maxArrayLength);
}

BubbleSort<int> bubbleSort = new ();
QuickSort<int> quickSort = new ();
var distinctValues = array.Distinct().ToArray();

MeasureTimePerformance _measure = new ();
Console.WriteLine("Sorting.... with bubble sort algorithm");
//_measure.Init();
//_measure.Start();

//bubbleSort.Sort(distinctValues);

//_measure.Stop();

//Console.WriteLine($"Bubble tree sort function completed in ${_measure.GetElapsedTime()}");

Console.WriteLine("Sorting.... with quicksort algorithm");
_measure.Init();
_measure.Start();

quickSort.Sort(distinctValues);
Console.WriteLine($"Quicksort function completed in ${_measure.GetElapsedTime()}");

_measure.Stop();

Console.ReadLine();

