namespace GetAllIndexes;

public static class ListExtensions
{
    /// <summary>
    /// A convenience method that walks through a list using FindIndex to return all indexes for a given reference
    /// </summary>
    public static IEnumerable<int> FindAllIndexes_v1<T>(this List<T> list, T reference) where T : notnull
    {
        ArgumentNullException.ThrowIfNull(list);
        
        var index = list.FindIndex(FindNextMatch());
        while (index != -1)
        {
            yield return index;
            index = list.FindIndex(index + 1, FindNextMatch());
        }

        yield break;

        Predicate<T> FindNextMatch()
        {
            return x => x.Equals(reference);
        }
    }

    /// <summary>
    /// Simpler (and ultimately more performant) implementation that iterates through the whole list once, returning all indexes for a given reference
    /// </summary>
    public static IEnumerable<int> FindAllIndexes_v2<T>(this List<T> list, T reference) where T : notnull
    {
        ArgumentNullException.ThrowIfNull(list);
        
        for (var i = 0; i < list.Count; i++)
        {
            if (list[i].Equals(reference))
            {
                yield return i;
            }
        }
    }
}