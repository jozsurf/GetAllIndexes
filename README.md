# Get All Indexes

This project arose out of the need to be able to efficiently locate all the indexes of a particular item in a list (which comes up a surprising number of times in HackerRank problems).

The [first solution](https://github.com/jozsurf/GetAllIndexes/blob/master/GetAllIndexes/ListExtensions.cs) is an extension method on `List<T>` where `FindIndex` is doing the heavy lifting. It returns an `IEnumerable` and utlizes `yield return` so that the caller can decide to end the enumeration without having to enumerate through the whole list.

This solution works well with medium-sized lists but started to struggle when the list sizes grew - particularly when all the indexes were required (which meant that the whole list had to be enumerated).

A simpler alternative to this first solution which iterates through the whole list, comparing values was surprisingly found to be more performant compared to the `FindIndex` solution.

The [second solution](https://github.com/jozsurf/GetAllIndexes/blob/master/GetAllIndexes/WrappedList.cs) utlizes a dictionary to be able to retrieve all the indexes of a given item. There is an upfront cost that needs to be paid to utilize this method (i.e. the whole list needs to be enumerated to be able to build up this dictionary lookup). Once done - and assuming the underlying list does not change - retrieving all indexes for a given item would have a constant time complexity i.e. `O(1)`. This makes this method ideal for scenarios where the indexes have to be retrieved repeatedly.

### Benchmarks

| Method                                 | Mean            | Error         | StdDev        |
|--------------------------------------- |----------------:|--------------:|--------------:|
| FindIndex_SmallList                    |        152.5 ns |       2.48 ns |       2.32 ns |
| SimpleIteration_SmallList              |        101.6 ns |       1.43 ns |       1.19 ns |
| Lookup_SmallList                       |        195.1 ns |       3.97 ns |      11.12 ns |
| FindIndex_LargeList                    | 11,065,218.8 ns | 199,102.68 ns | 348,712.28 ns |
| SimpleIteration_LargeList              | 10,243,168.4 ns |  17,365.55 ns |  14,501.02 ns |
| Lookup_LargeList                       |  8,398,556.9 ns | 101,037.95 ns |  89,567.51 ns |
| FindIndex_LargeListWithOneRepeat       | 22,105,056.8 ns | 410,663.67 ns | 750,921.74 ns |
| SimpleIteration_LargeListWithOneRepeat | 20,583,240.6 ns | 164,522.17 ns | 145,844.62 ns |
| Lookup_LargeListWithOneRepeat          |  8,438,344.8 ns |  89,310.62 ns |  83,541.21 ns |

