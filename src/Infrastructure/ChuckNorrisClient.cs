using System.Text.Json;
using Core.Interfaces;
using Core.Models;

namespace Infrastructure;

public class ChuckNorrisClient : IChuckNorrisClient
{
    private readonly HttpClient _client;

    public ChuckNorrisClient(IHttpClientFactory httpClientFactory)
    {
        _client = httpClientFactory.CreateClient(nameof(ChuckNorrisClient));
    }

    public async Task<ChuckNorrisResponseDto> GetRandomJoke()
    {
        var response = await _client.GetStringAsync("jokes/random");
        return JsonSerializer.Deserialize<ChuckNorrisResponseDto>(response);
    }
}