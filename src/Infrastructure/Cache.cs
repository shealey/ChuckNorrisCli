using Core.Interfaces;

namespace Infrastructure;

public class Cache : ICache
{
    private readonly List<string> _jokes;

    public Cache()
    {
        _jokes = new List<string>();
    }

    public void Add(string joke)
    {
        if (string.IsNullOrWhiteSpace(joke))
        {
            return;
        }

        if (!_jokes.Contains(joke))
        {
            _jokes.Add(joke);
        }
    }

    public int FindIndex(string joke)
    {
        if (string.IsNullOrWhiteSpace(joke))
        {
            return -1;
        }

        return _jokes.IndexOf(joke);
    }

    public string Get(int index)
    {
        return _jokes.ElementAtOrDefault(index);
    }
}