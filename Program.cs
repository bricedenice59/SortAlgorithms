using SortAlgorithms;
using SortAlgorithms.Utils;
using System.Security.Cryptography;

int maxArrayLength = (int)1e4;
int[] array = new int[maxArrayLength];

for (int i = 0; i < maxArrayLength; i++)
{
    array[i] = RandomNumberGenerator.GetInt32(1, maxArrayLength);
}
var distinctValues = array.Distinct().ToArray();

Console.WriteLine($"Try sorting array of {maxArrayLength} integers...");

BubbleSort bubbleSort = new ();

MeasureTimePerformance _measure = new ();
Console.WriteLine("Sorting.... with bubble sort algorithm");
_measure.Init();
_measure.Start();

bubbleSort.Sort(distinctValues);

_measure.Stop();

Console.WriteLine($"Bubble tree sort function completed in ${_measure.GetElapsedTime()}");

Console.WriteLine("Sorting.... with quicksort algorithm");
array = new int[maxArrayLength];

for (int i = 0; i < maxArrayLength; i++)
{
    array[i] = RandomNumberGenerator.GetInt32(1, maxArrayLength);
}
distinctValues = array.Distinct().ToArray();
QuickSort quickSort = new();

_measure.Init();
_measure.Start();

quickSort.Sort(distinctValues);
Console.WriteLine($"Quicksort function completed in ${_measure.GetElapsedTime()}");

_measure.Stop();


HeapSort<int> heapSort = new();
array = new int[maxArrayLength];

for (int i = 0; i < maxArrayLength; i++)
{
    array[i] = RandomNumberGenerator.GetInt32(1, maxArrayLength);
}
distinctValues = array.Distinct().ToArray();
for (int j = 0; j < distinctValues.Length; j++)
{
    heapSort.Insert(distinctValues[j]);
}


Console.ReadLine();

