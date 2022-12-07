using AutoFixture;
using Core.Interfaces;
using Core.Services;
using NSubstitute;

namespace Core.Tests.Services.JokeServiceTests;

public class JokeServiceTestContext
{
    public JokeServiceTestContext()
    {
        ChuckNorrisClient = Substitute.For<IChuckNorrisClient>();
        Cache = Substitute.For<ICache>();
        Fixture = new Fixture();
        Sut = new JokeService(ChuckNorrisClient, Cache);
    }

    public JokeService Sut { get; set; }
    public IChuckNorrisClient ChuckNorrisClient { get; set; }
    public ICache Cache { get; set; }
    public Fixture Fixture { get; set; }
}
