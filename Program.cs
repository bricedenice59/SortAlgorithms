using SortAlgorithms;
using SortAlgorithms.Utils;
using System.Security.Cryptography;

int maxArrayLength = (int)1e5;
int[] array = new int[maxArrayLength];

for (int i = 0; i < maxArrayLength; i++)
{
    array[i] = RandomNumberGenerator.GetInt32(1, maxArrayLength);
}

BubbleSort<int> bubbleSort = new ();
var distinctValues = array.Distinct().ToArray();

MeasureTimePerformance _measure = new ();
_measure.Init();
_measure.Start();

bubbleSort.Sort(distinctValues);

_measure.Stop();

Console.WriteLine($"Bubble tree sort function completed in ${_measure.GetElapsedTime()}");

Array.Sort(array);

Console.ReadLine();

