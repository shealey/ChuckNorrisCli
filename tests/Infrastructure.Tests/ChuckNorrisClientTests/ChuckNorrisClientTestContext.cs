using System.Net.Http;
using AutoFixture;
using NSubstitute;

namespace Infrastructure.Tests.ChuckNorrisClientTests
{
    public class ChuckNorrisClientTestContext
    {
        public ChuckNorrisClientTestContext()
        {
            HttpClientFactory = Substitute.For<IHttpClientFactory>();
            Sut = new ChuckNorrisClient(HttpClientFactory);
            Fixture = new Fixture();
        }

        public ChuckNorrisClient Sut { get; set; }
        public IHttpClientFactory HttpClientFactory { get; set; }
        public Fixture Fixture { get; set; }
    }
}
