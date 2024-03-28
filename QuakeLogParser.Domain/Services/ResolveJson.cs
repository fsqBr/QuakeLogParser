using QuakeLogParser.Domain.Entities;
using QuakeLogParser.Domain.Services.Interface;
using System.Text.Json;

namespace QuakeLogParser.Domain.Services
{
    public class ResolveJson : IResolveJson
    {
        /// <summary>
        /// Return the json with the games
        /// </summary>
        /// <typeparam name="T">Generec type to process the list to json</typeparam>
        /// <param name="lsGames">Parsed log or Report data</param>
        /// <returns>Converted json string</returns>        
        public Task<string> ReturnJson<T>(List<T> lsGames) where T : IGame
        {

            if(lsGames == null || lsGames.Count ==0 )
                throw new ArgumentNullException(nameof(lsGames), "Games not found");

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            };            

            var formatJson = new Dictionary<string, T>();
            lsGames.ForEach(x => formatJson.Add(x.Name, x));
            return Task.FromResult(JsonSerializer.Serialize(formatJson, options));
        }
    }
}
