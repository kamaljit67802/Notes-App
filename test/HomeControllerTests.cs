using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using Mynotes;

namespace Mynotes.Tests
{
    public class HomeControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public HomeControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetHomePageReturnsSuccessStatusCode()
        {            
            var client = _factory.CreateClient();            
            var response = await client.GetAsync("/login");            
            response.EnsureSuccessStatusCode();
        }

    }
}