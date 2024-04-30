# Get All Indexes

This project arose out of the need to be able to efficiently locate all the indexes of a particular item in a list (which comes up a surprising number of times in HackerRank problems).

The [first solution](https://github.com/jozsurf/GetAllIndexes/blob/master/GetAllIndexes/ListExtensions.cs) is an extension method on `List<T>` where `FindIndex` is doing the heavy lifting. It returns an `IEnumerable` and utlizes `yield return` so that the caller can decide to end the enumeration without having to enumerate through the whole list.

This solution works well with medium-sized lists but started to struggle when the list sizes grew - particularly when all the indexes were required (which meant that the whole list had to be enumerated).

The [second solution](https://github.com/jozsurf/GetAllIndexes/blob/master/GetAllIndexes/WrappedList.cs) utlizes a dictionary to be able to retrieve all the indexes of a given item. There is an upfront cost that needs to be paid to utilize this method (i.e. the whole list needs to be enumerated to be able to build up this dictionary lookup). Once done - and assuming the underlying list does not change - retrieving all indexes for a given item would have a constant time complexity i.e. `O(1)`. This makes this method ideal for scenarios where the indexes have to be retrieved repeatedly.

### Benchmarks

| Method                           | Mean            | Error         | StdDev          | Median          |
|--------------------------------- |----------------:|--------------:|----------------:|----------------:|
| FindIndex_SmallList              |        128.7 ns |       0.86 ns |         0.81 ns |        128.8 ns |
| Lookup_SmallList                 |        173.6 ns |       3.51 ns |         8.60 ns |        170.5 ns |
| FindIndex_LargeList              | 12,462,558.9 ns | 312,168.19 ns |   910,609.25 ns | 12,362,471.9 ns |
| Lookup_LargeList                 |  8,622,792.0 ns | 148,866.63 ns |   139,249.93 ns |  8,619,154.7 ns |
| FindIndex_LargeListWithOneRepeat | 22,834,194.7 ns | 514,618.66 ns | 1,459,887.49 ns | 22,405,675.0 ns |
| Lookup_LargeListWithOneRepeat    |  8,344,775.9 ns |  58,932.88 ns |    52,242.46 ns |  8,362,004.7 ns |
