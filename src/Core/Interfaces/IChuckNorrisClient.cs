using Core.Models;

namespace Core.Interfaces;

public interface IChuckNorrisClient
{
    Task<ChuckNorrisResponseDto> GetRandomJoke();
}