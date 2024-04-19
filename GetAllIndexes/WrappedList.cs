namespace GetAllIndexes;

public class WrappedList<T> where T : notnull
{
    public List<T> List { get; private set; }
    private readonly Dictionary<T, List<int>> _indexLookup = new();
    
    public WrappedList(List<T> list)
    {
        List = list;

        for (var i = 0; i < list.Count; i++)
        {
            var value = list[i];
            if (_indexLookup.TryGetValue(value, out var indexes))
            {
                indexes.Add(i);
            }
            else
            {
                _indexLookup[value] = [i];
            }
        }
    }

    public List<int> FindAllIndexes(T reference)
    {
        if (_indexLookup.TryGetValue(reference, out var indexes))
        {
            return indexes;
        }

        return [];
    }
}