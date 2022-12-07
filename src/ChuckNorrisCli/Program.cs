using Core;
using Core.Interfaces;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddInfrastructure("https://api.chucknorris.io/")
    .AddCore()
    .BuildServiceProvider();

var jokeService = serviceProvider.GetRequiredService<IJokeService>();
ConsoleKeyInfo key;
var joke = string.Empty;

Console.WriteLine("Welcome to the Chuck Norris Joke CLI!");
Console.WriteLine("Commands: j=new | n=next | p=previous | esc=exit");

do
{
    key = Console.ReadKey();
    if (key.Key == ConsoleKey.J)
    {
        joke = await jokeService.GetJoke();
    }
    else if (key.Key == ConsoleKey.P)
    {
        joke = jokeService.Previous(joke);
    }
    else if (key.Key == ConsoleKey.N)
    {
        joke = jokeService.Next(joke);
    }
    else if (key.Key != ConsoleKey.Escape)
    {
        continue;
    }

    Console.WriteLine(string.Empty);
    Console.WriteLine(joke);
}
while (key.Key != ConsoleKey.Escape);