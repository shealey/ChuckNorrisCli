namespace Core.Interfaces;

public interface IJokeService
{
    Task<string> GetJoke();
    string Next(string joke);
    string Previous(string joke);
}