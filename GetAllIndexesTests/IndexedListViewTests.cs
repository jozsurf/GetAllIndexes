using GetAllIndexes;
using NUnit.Framework;

namespace GetAllIndexesTests;

[TestFixture]
public class IndexedListViewTests
{
    [Test]
    public void FindAllIndexes_WhenReferencesInListExist_AllIndexesWillBeReturned()
    {
        List<int> list = [1, 1, 10, 3, 9, 10, 25, 36, 11, 23];
        var wrapped = new IndexedListView<int>(list);
        
        var result = wrapped.FindAllIndexes(10);

        Assert.That(result.SequenceEqual([2, 5]));
    }
    
    [Test]
    public void FindAllIndexes_WhenReferencesInListDoNotExist_EmptyListReturned()
    {
        List<int> list = [1, 1, 10, 3, 9, 10, 25, 36, 11, 23];
        var wrapped = new IndexedListView<int>(list);

        var result = wrapped.FindAllIndexes(100).ToList();

        Assert.That(result.SequenceEqual([]));
    }
}