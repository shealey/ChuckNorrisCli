using AutoFixture;
using FluentAssertions;
using Xunit;

namespace Infrastructure.Tests.CacheTests
{
    public class FindIndexShould
    {
        private readonly Cache _sut = new();
        private readonly Fixture _fixture = new();

        [Fact]
        public void ReturnExpectedCacheIndex_WhenJokeIsCached()
        {
            // Arrange
            var one = _fixture.Create<string>();
            var two = _fixture.Create<string>();
            var three = _fixture.Create<string>();

            // Act
            _sut.Add(one);
            _sut.Add(two);
            _sut.Add(three);

            var expected = 2;
            var actual = _sut.FindIndex(three);

            // Assert
            actual.Should().Be(expected);
        }

        [Fact]
        public void ReturnMinusOne_WhenJokeIsNotCached()
        {
            // Arrange
            var one = _fixture.Create<string>();
            var two = _fixture.Create<string>();
            var three = _fixture.Create<string>();

            // Act
            _sut.Add(one);
            _sut.Add(two);
            _sut.Add(three);

            var expected = -1;
            var actual = _sut.FindIndex("some other joke");

            // Assert
            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("    ")]
        [InlineData("")]
        public void ReturnMinusOne_WhenInputIsNullOrWhitespace(string input)
        {
            // Arrange
            var one = _fixture.Create<string>();
            var two = _fixture.Create<string>();
            var three = _fixture.Create<string>();

            // Act
            _sut.Add(one);
            _sut.Add(two);
            _sut.Add(three);
            var index = _sut.FindIndex(input);

            // Assert
            index.Should().Be(-1);
        }
    }
}
