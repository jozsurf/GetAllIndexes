using GetAllIndexes;
using NUnit.Framework;

namespace GetAllIndexesTests;

[TestFixture]
public class ListExtensionsTests
{
    [Test]
    public void FindAllIndexes_v1_WhenReferencesInListExist_AllIndexesWillBeReturned()
    {
        List<int> list = [1, 1, 10, 3, 9, 10, 25, 36, 11, 23];

        var result = list.FindAllIndexes_v1(10).ToList();

        Assert.That(result.SequenceEqual([2, 5]));
    }
    
    [Test]
    public void FindAllIndexes_v1_WhenReferencesInListDoNotExist_EmptyListReturned()
    {
        List<int> list = [1, 1, 10, 3, 9, 10, 25, 36, 11, 23];

        var result = list.FindAllIndexes_v1(100).ToList();

        Assert.That(result.SequenceEqual([]));
    }
    
    [Test]
    public void FindAllIndexes_v2_WhenReferencesInListExist_AllIndexesWillBeReturned()
    {
        List<int> list = [1, 1, 10, 3, 9, 10, 25, 36, 11, 23];

        var result = list.FindAllIndexes_v2(10).ToList();

        Assert.That(result.SequenceEqual([2, 5]));
    }
    
    [Test]
    public void FindAllIndexes_v2_WhenReferencesInListDoNotExist_EmptyListReturned()
    {
        List<int> list = [1, 1, 10, 3, 9, 10, 25, 36, 11, 23];

        var result = list.FindAllIndexes_v2(100).ToList();

        Assert.That(result.SequenceEqual([]));
    }
}