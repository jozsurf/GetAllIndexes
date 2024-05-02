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
        _smallList.FindAllIndexes_v1(0).ToList();
    }
    
    [Benchmark]
    public void SimpleIteration_SmallList()
    {
        _smallList.FindAllIndexes_v2(0).ToList();
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
        _largeList.FindAllIndexes_v1(0).ToList();
    }
    
    [Benchmark]
    public void SimpleIteration_LargeList()
    {
        _largeList.FindAllIndexes_v2(0).ToList();
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
        _largeList.FindAllIndexes_v1(0).ToList();
        _largeList.FindAllIndexes_v1(1).ToList();
    }
    
    [Benchmark]
    public void SimpleIteration_LargeListWithOneRepeat()
    {
        _largeList.FindAllIndexes_v2(0).ToList();
        _largeList.FindAllIndexes_v2(1).ToList();
    }

    [Benchmark]
    public void Lookup_LargeListWithOneRepeat()
    {
        var wrappedList = new WrappedList<int>(_largeList);
        wrappedList.FindAllIndexes(0);        
        wrappedList.FindAllIndexes(1);        
    }
}