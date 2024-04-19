namespace GetAllIndexes;

public static class ListExtensions
{
    public static IEnumerable<int> FindAllIndexes<T>(this List<T> list, T reference) where T : notnull
    {
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
}