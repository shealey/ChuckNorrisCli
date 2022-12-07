using AutoFixture;
using FluentAssertions;
using Xunit;

namespace Infrastructure.Tests.CacheTests
{
    public class GetShould
    {
        private readonly Cache _sut = new();
        private readonly Fixture _fixture = new();

        [Fact]
        public void ReturnExpectedValue_WhenCacheHasValueAtIndex()
        {
            // Arrange
            var one = _fixture.Create<string>();
            var two = _fixture.Create<string>();
            var expected = _fixture.Create<string>();

            // Act
            _sut.Add(one);
            _sut.Add(two);
            _sut.Add(expected);

            var actual = _sut.Get(2);

            // Assert
            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(3)]
        public void ReturnNull_WhenCacheDoesNotHaveValueAtIndex(int index)
        {
            // Arrange
            var one = _fixture.Create<string>();
            var two = _fixture.Create<string>();
            var expected = _fixture.Create<string>();

            // Act
            _sut.Add(one);
            _sut.Add(two);
            _sut.Add(expected);

            var actual = _sut.Get(index);

            // Assert
            actual.Should().BeNull();
        }
    }
}
