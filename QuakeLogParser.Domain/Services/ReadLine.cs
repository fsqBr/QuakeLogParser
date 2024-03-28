using QuakeLogParser.Domain.Entities;
using QuakeLogParser.Domain.Services.Interface;

namespace QuakeLogParser.Domain.Services
{
    public class ReadLine : IReadLine
    {
        private readonly IReadMatch _readMatch;
        public ReadLine(IReadMatch readMatch)
        {
            this._readMatch = readMatch;
        }

        /// <summary>
        /// Read the line and return the game with the kills
        /// </summary>
        /// <param name="line">Line of the log file</param>
        /// <param name="game">Valid game</param>
        /// <returns>Information of game match KillandDeath</returns>        
        public Task<Game> ReadKill(string line, Game game)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(line, "line log not found");

            if(game == null)
             throw new ArgumentNullException(nameof(game), "Game log not found");

            if (line.Contains("Kill"))
            {
                if (game.GameMatchs == null)
                {
                    game.GameMatchs = new List<GameMatch>();
                }
                game.GameMatchs.AddRange(_readMatch.GetInfoPlayers(line).Result);
            }

            return Task.FromResult<Game>(game);
        }

        /// <summary>
        /// Read the line and return the game
        /// </summary>
        /// <param name="line">Line of the log file</param>
        /// <param name="game">Valid game</param>
        /// <returns>New game</returns>
        public Task<Game> ReadInitGame(string line, List<Game> games)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(line, "line log notfound");

            Game game = null;
            if (line.Contains("InitGame"))
            {
                game = new Game();
                game.Id = Guid.NewGuid();
                game.Name = $"Game_{games.Count + 1}";
            }

            return Task.FromResult<Game>(game);
        }
        
    }
}
