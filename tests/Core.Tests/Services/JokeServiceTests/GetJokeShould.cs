using AutoFixture;
using Core.Interfaces;
using Core.Models;
using Core.Services;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Core.Tests.Services.JokeServiceTests;

public class GetJokeShould
{
    private readonly JokeService _sut;
    private readonly IChuckNorrisClient _client;
    private readonly ICache _cache;
    private readonly Fixture _fixture;

    public GetJokeShould()
    {
        var context = new JokeServiceTestContext();
        _sut = context.Sut;
        _cache = context.Cache;
        _client = context.ChuckNorrisClient;
        _fixture = context.Fixture;
    }

    [Fact]
    public async void ReturnRandomJoke_WhenCalled()
    {
        // Arrange
        var response = _fixture.Create<ChuckNorrisResponseDto>();
            
        _client
            .GetRandomJoke()
            .Returns(response);

        // Act
        var expected = response.Value;
        var actual = await _sut.GetJoke();

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async void AddJokeToCache_WhenCalled()
    {
        // Arrange
        var response = _fixture.Create<ChuckNorrisResponseDto>();

        _client
            .GetRandomJoke()
            .Returns(response);

        // Act
        await _sut.GetJoke();

        // Assert
        _cache.Received(1).Add(response.Value);
    }
}
