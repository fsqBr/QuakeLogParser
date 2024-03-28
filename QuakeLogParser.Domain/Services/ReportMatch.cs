using QuakeLogParser.Domain.Entities;
using QuakeLogParser.Domain.Services.Interface;

namespace QuakeLogParser.Domain.Services
{
    public class ReportMatch : IReportMatch
    {
        /// <summary>
        /// Get the players and the weapon used in the match
        /// </summary>
        /// <param name="lsPlayers">List of players</param>
        /// <param name="gameMatches">List of Matches</param>
        /// <returns>Group nformation about kill and death player</returns>        
        public Task<Dictionary<string, int>> GetPlayersStats(List<string> lsPlayers, List<GameMatch> gameMatches)
        {

            if (lsPlayers == null || lsPlayers.Count == 0)
                throw new ArgumentNullException(nameof(lsPlayers), "Players not found");

            if (gameMatches == null || gameMatches.Count == 0)
                throw new ArgumentNullException(nameof(gameMatches), "GameMatch not found");

            var playerStats = new Dictionary<string, int>();
            lsPlayers.ForEach(p =>
            {
                var kills = gameMatches.Where(x => x.Player == p && x.Action == TypeActionEnum.Kill).Count();
                var death = gameMatches.Where(x => x.Player == p && x.Action == TypeActionEnum.Death).Count();
                playerStats.Add(p, kills - death);
            });

            return Task.FromResult(playerStats);
        }

        /// <summary>
        /// Get the weapon used in the match
        /// </summary>
        /// <param name="gameMatches">List of matches from the game</param>
        /// <returns>Weapons with the score </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Task<Dictionary<string, int>> GetWeaponStats(List<GameMatch> gameMatches)
        {
            if (gameMatches == null || gameMatches.Count == 0)
                throw new ArgumentNullException(nameof(gameMatches), "GameMatch not found");

            var WeaponStats = new Dictionary<string, int>();
            gameMatches.Where(x => !string.IsNullOrEmpty(x.Weppon))
                      .Select(x => x.Weppon)
                      .Distinct()
                      .ToList().ForEach(w =>
                      {
                          WeaponStats.Add(w, gameMatches.Where(x => x.Weppon == w).Count());
                      });

            return Task.FromResult(WeaponStats);
        }

        /// <summary>
        /// Grup the match by game
        /// </summary>
        /// <param name="games">List of the games parsed</param>
        /// <param name="withWeapon">Indicates if weapon stats or not</param>
        /// <returns>json formated with game stats</returns>        
        public Task<List<ReportGame>> GroupedMatch(List<Game> games, bool withWeapon)
        {

            if(games == null || games.Count == 0)
                throw new ArgumentNullException(nameof(games), "Games not found");  

            List<ReportGame> lsReport = new List<ReportGame>();
            int count = 0;

            games.Where(x => x.GameMatchs != null)
                 .GroupBy(x => x.Id)
                 .ToList()
                 .ForEach(group =>
                 {
                     count++;
                     ReportGame reportGame = new ReportGame();
                     var gameMatchs = group.FirstOrDefault().GameMatchs;
                     reportGame.Id = group.Key;
                     reportGame.Total_Kills = gameMatchs.Where(g => g.Action == TypeActionEnum.Kill).Count();
                     reportGame.Players = gameMatchs.Where(x => x.IsPlayer == true).Select(x => x.Player).Distinct().ToList();
                     reportGame.Name = $"game_{count}";
                     reportGame.Kills = GetPlayersStats(reportGame.Players, gameMatchs).Result;

                     if (withWeapon)
                         reportGame.Kills_By_Means = GetWeaponStats(gameMatchs).Result;

                     lsReport.Add(reportGame);
                 });


            return Task.FromResult(lsReport);
        }
    }
}
