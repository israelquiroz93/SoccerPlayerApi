using Microsoft.AspNetCore.Mvc.Testing;
using SoccerPlayerApi.Models;
using System.Net.Http.Json;
using Xunit;

namespace SoccerPlayerAPISUT
{
    public class BasicTests
        : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private HttpClient _httpClient;

        public BasicTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _httpClient = _factory.CreateDefaultClient();
        }

        [Fact]
        [InlineData("/GetPlayers")]
        public async Task GetPlayers_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            var response = await _httpClient.GetAsync("/api/Players/GetPlayers");
            var result = await response.Content.ReadFromJsonAsync<List<Player>>();
            response.EnsureSuccessStatusCode(); 
        }
    }


}