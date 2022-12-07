namespace Core.Interfaces;

public interface ICache
{
    void Add(string joke);
    int FindIndex(string joke);
    string Get(int index);
}