using Microsoft.AspNetCore.Mvc;
using SoccerPlayerApi.Data.Interfaces;

namespace SoccerPlayerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SPController : ControllerBase
    {
        private readonly ISPRepository _spRepository;

        public SPController(ISPRepository sPRepository)
        {
            _spRepository = sPRepository;
        }

        [HttpGet("GetPlayer")]
        public async Task<Player> GetPlayer(string name, int jerseyNumber)
        {
            var x = await _spRepository.GetPlayer(name, jerseyNumber);
            return x;
        }

        [HttpGet("GetPlayersList")]
        public async Task<List<Player>> GetPlayersList()
        {
            var x = await _spRepository.GetPlayersList();
            return x;
        }


        [HttpGet("CreatePlayer")]
        public async Task<int> CreatePlayer(int jerseyNumber, string name, int teamId)
        {
            var x = await _spRepository.CreatePlayer(jerseyNumber, name, teamId);
            return x;
        }

        [HttpGet("UpdatePlayer")]
        public async Task<int> UpdatePlayer(int teamId, int playerId)
        {
            var x = await _spRepository.UpdatePlayer(teamId, playerId);
            return x;
        }

        [HttpGet("GetJoinedPlayerList")]
        public async Task<dynamic> GetJoinedPlayerList()
        {
            var x = await _spRepository.GetJoinedPlayerList();
            return x;
        }
    }
}
