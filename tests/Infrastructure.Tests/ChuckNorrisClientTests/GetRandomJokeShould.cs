using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using AutoFixture;
using Core.Models;
using FluentAssertions;
using Infrastructure.Tests.Fakes;
using NSubstitute;
using Xunit;

namespace Infrastructure.Tests.ChuckNorrisClientTests
{
    public class GetRandomJokeShould
    {
        private readonly Fixture _fixture = new();

        [Fact]
        public async void ReturnExpectedResponse_WhenCalled()
        {
            // Arrange
            var factory = Substitute.For<IHttpClientFactory>();
            var expected = _fixture.Create<ChuckNorrisResponseDto>();
            var handler = new FakeHttpMessageHandler(JsonSerializer.Serialize(expected), HttpStatusCode.OK);
            using var client = new HttpClient(handler)
            {
                BaseAddress = new ("https://localhost")
            };

            factory
                .CreateClient(nameof(ChuckNorrisClient))
                .Returns(client);

            var sut = new ChuckNorrisClient(factory);

            // Act
            var actual = await sut.GetRandomJoke();

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async void CallExpectedEndpoint_WhenCalled()
        {
            // Arrange
            var factory = Substitute.For<IHttpClientFactory>();
            var response = _fixture.Create<ChuckNorrisResponseDto>();
            var handler = new FakeHttpMessageHandler(JsonSerializer.Serialize(response), HttpStatusCode.OK);
            using var client = new HttpClient(handler)
            {
                BaseAddress = new("https://localhost")
            };

            factory
                .CreateClient(nameof(ChuckNorrisClient))
                .Returns(client);

            var sut = new ChuckNorrisClient(factory);

            // Act
            var expected = new Uri("https://localhost/jokes/random");
            await sut.GetRandomJoke();

            // Assert
            handler.Calls.Should()
                .HaveCount(1).And
                .OnlyContain(c => c.RequestUri == expected);
        }
    }
}
