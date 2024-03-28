using QuakeLogParser.Domain.Entities;
using QuakeLogParser.Domain.Services.Interface;

namespace QuakeLogParser.Domain.Services
{
    public class Parser : IParser
    {
        private readonly IReadLine _readLine;
        public Parser(IReadLine readLine)
        {
            this._readLine = readLine
;
        }
        /// <summary>
        /// Read the Quake log file and return a list of games
        /// </summary>
        /// <param name="log">Path from log file</param>
        /// <returns>List of all games</returns>        
        public Task<List<Game>> Read(string log)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(log, "Log file notfound");

            string[] lines = File.ReadAllLines(log);

            if (lines.Length == 0)
                throw new Exception("File is empty");

            List<Game> list = new List<Game>();

            foreach (var item in lines)
            {
                var game = _readLine.ReadInitGame(item, list).Result;

                if (game != null)
                {
                    list.Add(game);
                    continue;
                }

                game = list.LastOrDefault();

                if (game != null)
                    _readLine.ReadKill(item, game);

            }

            return Task.FromResult(list);
        }

    }
}
