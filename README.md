# Get All Indexes

This project arose out of the need to be able to efficiently locate all the indexes of a particular item in a list (which comes up a surprising number of times in HackerRank problems).

The [first solution](https://github.com/jozsurf/GetAllIndexes/blob/master/GetAllIndexes/ListExtensions.cs) is an extension method on `List<T>` where `FindIndex` is doing the heavy lifting. It returns an `IEnumerable` and utlizes `yield return` so that the caller can decide to end the enumeration without having to enumerate through the whole list.

This solution works well with medium-sized lists but started to struggle when the list sizes grew - particularly when all the indexes were required (which meant that the whole list had to be enumerated).

The [second solution](https://github.com/jozsurf/GetAllIndexes/blob/master/GetAllIndexes/WrappedList.cs) utlizes a dictionary to be able to retrieve all the indexes of a given item. There is an upfront cost that needs to be paid to utilize this method (i.e. the whole list needs to be enumerated to be able to build up this dictionary lookup). Once done - and assuming the underlying list does not change - retrieving all indexes for a given item would have a constant time complexity i.e. `O(1)`. This makes this method ideal for scenarios where the indexes have to be retrieved repeatedly.

### Benchmarks

| Test                                        | Run time |
|---------------------------------------------| ---------|
| Small list of integers (10) using FindIndex | 1 ms |
| Small list of integers (10) using Lookup | 1 ms |
| Large list of integers (1000000) using FindIndex | 32 ms |
| Large list of integers (1000000) using Lookup | 16 ms |
| Large list of integers with one repeat using FindIndex | 73 ms |
| Large list of integers with one repeat using Lookup | 15 ms |