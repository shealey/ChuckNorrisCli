using AutoFixture;
using Core.Interfaces;
using Core.Services;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Core.Tests.Services.JokeServiceTests
{
    public class PreviousShould
    {
        private readonly JokeService _sut;
        private readonly ICache _cache;
        private readonly Fixture _fixture;

        public PreviousShould()
        {
            var context = new JokeServiceTestContext();
            _sut = context.Sut;
            _cache = context.Cache;
            _fixture = context.Fixture;
        }

        [Fact]
        public void ReturnExpectedJoke_WhenPreviousJokeExistsInCache()
        {
            // Arrange
            var joke = _fixture.Create<string>();
            var expected = _fixture.Create<string>();

            _cache
                .FindIndex(joke)
                .Returns(6);

            _cache
                .Get(5)
                .Returns(expected);

            // Act
            var actual = _sut.Previous(joke);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void ReturnSameJoke_WhenPreviousJokeDoesNotExistInCache()
        {
            // Arrange
            var expected = _fixture.Create<string>();

            _cache
                .FindIndex(expected)
                .Returns(6);

            _cache
                .Get(5)
                .Returns((string)null);

            // Act
            var actual = _sut.Previous(expected);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
