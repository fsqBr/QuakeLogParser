using QuakeLogParser.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuakeLogParser.Domain.Services.Interface
{
    public interface IReportMatch
    {
        Task<List<ReportGame>> GroupedMatch(List<Game> games, bool withWeapon);

        Task<Dictionary<string, int>> GetPlayersStats(List<string> lsPlayers, List<GameMatch> gameMatches);

        Task<Dictionary<string, int>> GetWeaponStats(List<GameMatch> gameMatches);

        
    }
}
