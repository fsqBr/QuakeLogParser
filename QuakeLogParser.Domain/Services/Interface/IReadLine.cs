using QuakeLogParser.Domain.Entities;

namespace QuakeLogParser.Domain.Services.Interface
{
    public interface IReadLine
    {
        Task<Game> ReadInitGame(string line, List<Game> games);

        Task<Game> ReadKill(string line, Game game);
    }
}
