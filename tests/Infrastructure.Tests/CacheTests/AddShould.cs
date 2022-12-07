using AutoFixture;
using FluentAssertions;
using Xunit;

namespace Infrastructure.Tests.CacheTests
{
    public class AddShould
    {
        private readonly Cache _sut = new();
        private readonly Fixture _fixture = new();

        [Fact]
        public void AddToCache_WhenItDoesNotExist()
        {
            // Arrange
            var expected = _fixture.Create<string>();

            // Act
            _sut.Add(expected);
            var actual = _sut.Get(0);

            // Assert
            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("    ")]
        [InlineData("")]
        public void NotAddToCache_WhenInputIsNullOrWhitespace(string input)
        {
            // Arrange
            // Act
            _sut.Add(input);
            var index = _sut.FindIndex(input);

            // Assert
            index.Should().Be(-1);
        }
    }
}
