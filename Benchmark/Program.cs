using System.Diagnostics;
using GetAllIndexes;

#region integer testing
List<int>? smallList = [];
List<int>? largeList = [];

for (var i = 1; i <= 10; i++)
{
    smallList.Add(i % 2);
}

for (var i = 1; i <= 1000000; i++)
{
    largeList.Add(i % 2);
}

var stopwatch = new Stopwatch();

Console.WriteLine("Testing performance on lists of integers");
Console.WriteLine("Small list: ");

stopwatch.Start();
var result1 = smallList.FindAllIndexes(0).ToList();
stopwatch.Stop();

Console.WriteLine($"Using FindIndex: {stopwatch.ElapsedMilliseconds} ms");

stopwatch.Reset();
stopwatch.Start();
var wrappedList = new WrappedList<int>(smallList);
var result2 = wrappedList.FindAllIndexes(0);
stopwatch.Stop();

Console.WriteLine($"Using Dictionary lookup: {stopwatch.ElapsedMilliseconds} ms");
Console.WriteLine();

Console.WriteLine("Large list: ");

stopwatch.Start();
var result3 = largeList.FindAllIndexes(0).ToList();
stopwatch.Stop();

Console.WriteLine($"Using FindIndex: {stopwatch.ElapsedMilliseconds} ms");

stopwatch.Reset();
stopwatch.Start();
wrappedList = new WrappedList<int>(largeList);
var result4 = wrappedList.FindAllIndexes(0);
stopwatch.Stop();

Console.WriteLine($"Using Dictionary lookup: {stopwatch.ElapsedMilliseconds} ms");
Console.WriteLine();

smallList = null;
largeList = null;

#endregion