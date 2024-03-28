using QuakeLogParser.Domain.Entities;
using QuakeLogParser.Domain.Services.Interface;


namespace QuakeLogParser.Domain.Services
{
    public class ReadMatch : IReadMatch
    {
        /// <summary>
        /// Get the players and the weapon used in the match
        /// </summary>
        /// <param name="lineMatch">Line with match information</param>
        /// <returns>List with information about the players</returns>        
        public Task<List<GameMatch>> GetInfoPlayers(string lineMatch)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(lineMatch);

            List<GameMatch> list = new List<GameMatch>();

            var getPlayers = System.Text.RegularExpressions.Regex.Match(lineMatch, @":\s([^:]+)\skilled\s(.*?)\sby\s[a-zA-Z_]+");

            if(!getPlayers.Success)
                throw new Exception("Players not found");

            string killer = getPlayers.Groups[1].Value;
            ArgumentNullException.ThrowIfNullOrEmpty(killer,"Killer Player not found");

            string death = getPlayers.Groups[2].Value;
            ArgumentNullException.ThrowIfNullOrEmpty(killer, "Death Player not found");
                       

            Guid id = Guid.NewGuid();

            list.Add(new GameMatch()
            {
                Id = id,
                Action = TypeActionEnum.Kill,
                IsPlayer = killer == "<world>" ? false : true,
                Player = killer,
                Weppon = GetWeapon(lineMatch).Result
            });

            list.Add(new GameMatch()
            {
                Id = id,
                Action = TypeActionEnum.Death,
                IsPlayer = true,
                Player = death,
                Weppon = null
            });

            return Task.FromResult(list);
        }

        /// <summary>
        /// return the weapon used in the match
        /// </summary>
        /// <param name="lineMatch">Line with match information</param>
        /// <returns>The weapon useed to kill the player</returns>
        /// <exception cref="Exception"></exception>
        public Task<string> GetWeapon(string lineMatch)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(lineMatch);

            var getWeapon = System.Text.RegularExpressions.Regex.Match(lineMatch, @"(?<=by\s)(.*?)(?=$)");

            if (!getWeapon.Success)
                throw new Exception("Weanpon not found");

            string weppon = getWeapon.Groups[1].Value;

            ArgumentNullException.ThrowIfNullOrEmpty(weppon, "Weapon not found");

            return Task.FromResult(weppon);            
        }
    }
}
