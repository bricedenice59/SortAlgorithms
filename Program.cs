using System.ComponentModel;
using SortAlgorithms;
using SortAlgorithms.Utils;
using System.Security.Cryptography;

int maxArrayLength = (int)10e4;
int[] array = new int[maxArrayLength];

for (int i = 0; i < maxArrayLength; i++)
{
    array[i] = RandomNumberGenerator.GetInt32(1, maxArrayLength);
}

Console.WriteLine($"Try sorting array of {maxArrayLength} integers...");

BubbleSort bubbleSort = new();

MeasureTimePerformance _measure = new();
Console.WriteLine("Sorting.... with bubble sort algorithm");
_measure.Init();
_measure.Start();

bubbleSort.Sort(array.Distinct().ToArray());

_measure.Stop();

Console.WriteLine($"Bubble tree sort function completed in ${_measure.GetElapsedTime()}");

Console.WriteLine("Sorting.... with quicksort algorithm");
array = new int[maxArrayLength];

for (int i = 0; i < maxArrayLength; i++)
{
    array[i] = RandomNumberGenerator.GetInt32(1, maxArrayLength);
}
var distinctValues = array.Distinct().ToArray();
QuickSort quickSort = new();

_measure.Init();
_measure.Start();

quickSort.Sort(distinctValues);

_measure.Stop();

Console.WriteLine($"Quicksort function completed in ${_measure.GetElapsedTime()}");

Console.WriteLine("Sorting.... with heapsort algorithm");
HeapSort<int> heapSort = new();
array = new int[maxArrayLength];

for (int i = 0; i < maxArrayLength; i++)
{
    array[i] = RandomNumberGenerator.GetInt32(1, maxArrayLength);
}
var distinctValuesHeapSortInput = array.Distinct();

_measure.Init();
_measure.Start();

heapSort.Sort(distinctValuesHeapSortInput);

_measure.Stop();

Console.WriteLine($"Heapsort function completed in ${_measure.GetElapsedTime()}");

var sorted = heapSort.Items;

var height = heapSort.GetHeapHeight(distinctValues);
Console.WriteLine($"Heap has a height of {height}");

Console.WriteLine($"Press a key to exit.");
Console.ReadLine();

