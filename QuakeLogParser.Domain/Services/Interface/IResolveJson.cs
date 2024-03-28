using QuakeLogParser.Domain.Entities;

namespace QuakeLogParser.Domain.Services.Interface
{
    public interface IResolveJson
    {
        Task<string> ReturnJson<T>(List<T> lsGames) where T : IGame;
    }
}
