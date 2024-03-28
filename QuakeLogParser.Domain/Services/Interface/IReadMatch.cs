using QuakeLogParser.Domain.Entities;

namespace QuakeLogParser.Domain.Services.Interface
{
    public interface IReadMatch
    {
        Task<List<GameMatch>> GetInfoPlayers(string lineMatch);

        Task<string> GetWeapon(string lineMatch);
    }
}
