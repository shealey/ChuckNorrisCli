using Core.Interfaces;

namespace Core.Services;

public class JokeService : IJokeService
{
    private readonly IChuckNorrisClient _client;
    private readonly ICache _cache;

    public JokeService(IChuckNorrisClient client, ICache cache)
    {
        _client = client;
        _cache = cache;
    }

    public async Task<string> GetJoke()
    {
        var response = await _client.GetRandomJoke();
        var joke = response.Value;
        _cache.Add(joke);

        return joke;
    }

    public string Next(string joke)
    {
        var index = _cache.FindIndex(joke);
        return _cache.Get(index + 1) ?? joke;
    }

    public string Previous(string joke)
    {
        var index = _cache.FindIndex(joke);
        return _cache.Get(index - 1) ?? joke;
    }
}