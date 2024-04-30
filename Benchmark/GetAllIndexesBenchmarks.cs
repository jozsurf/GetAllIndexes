using BenchmarkDotNet.Attributes;
using GetAllIndexes;

namespace Benchmark;

public class GetAllIndexesBenchmarks
{
    private readonly List<int> _smallList = [];
    private readonly List<int> _largeList = [];

    public GetAllIndexesBenchmarks()
    {
        for (var i = 1; i <= 10; i++)
        {
            _smallList.Add(i % 2);
        }

        for (var i = 1; i <= 1000000; i++)
        {
            _largeList.Add(i % 2);
        }
    }

    [Benchmark]
    public void FindIndex_SmallList()
    {
        _smallList.FindAllIndexes(0).ToList();
    }

    [Benchmark]
    public void Lookup_SmallList()
    {
        var wrappedList = new WrappedList<int>(_smallList);
        wrappedList.FindAllIndexes(0);
    }

    [Benchmark]
    public void FindIndex_LargeList()
    {
        _largeList.FindAllIndexes(0).ToList();
    }

    [Benchmark]
    public void Lookup_LargeList()
    {
        var wrappedList = new WrappedList<int>(_largeList);
        wrappedList.FindAllIndexes(0);        
    }
    
    [Benchmark]
    public void FindIndex_LargeListWithOneRepeat()
    {
        _largeList.FindAllIndexes(0).ToList();
        _largeList.FindAllIndexes(1).ToList();
    }

    [Benchmark]
    public void Lookup_LargeListWithOneRepeat()
    {
        var wrappedList = new WrappedList<int>(_largeList);
        wrappedList.FindAllIndexes(0);        
        wrappedList.FindAllIndexes(1);        
    }
}