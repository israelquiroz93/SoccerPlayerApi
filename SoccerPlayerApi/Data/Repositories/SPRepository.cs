using SoccerPlayerApi.Data.Interfaces;

namespace SoccerPlayerApi.Data.Repositories
{
    public class SPRepository : ISPRepository
    {
        public readonly SampleDatabaseContext _databaseContext;

        public SPRepository(SampleDatabaseContext dbContext)
        {
            _databaseContext = dbContext;
        }

        public async Task<int> CreatePlayer(int jerseyNumber, string name, int teamId)
        {
            var affectedRows = await _databaseContext.Database.ExecuteSqlInterpolatedAsync($"exec CreatePlayer @jerseyNumber={jerseyNumber},@name={name}, @teamId={teamId}");

            return affectedRows;
        }

        public async Task<dynamic> GetJoinedPlayerList()
        {
            var playerspobjObj = await _databaseContext.Players.FromSqlInterpolated($"exec GetJoinedPlayerList").ToListAsync();

            return playerspobjObj;
        }

        public async Task<Player> GetPlayer(string name, int jerseyNumber)
        {
            var playerspobjObj = await _databaseContext.Players.FromSqlInterpolated($"exec GetPlayer @jerseyNumber={jerseyNumber}, @name={name}").ToListAsync();
            return playerspobjObj.FirstOrDefault();
        }

        public async Task<List<Player>> GetPlayersList()
        {
            var playerspobjObj = await _databaseContext.Players.FromSqlInterpolated($"exec GetPlayersList").ToListAsync();
            return playerspobjObj;
        }

        public async Task<int> UpdatePlayer(int teamId, int playerId)
        {
            var affectedRows = await _databaseContext.Database.ExecuteSqlInterpolatedAsync($"exec UpdatePlayer @teamId={teamId}, @playerId={playerId}");

            return affectedRows;
        }
    }
}
