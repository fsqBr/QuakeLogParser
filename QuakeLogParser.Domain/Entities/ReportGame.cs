using System.Text.Json.Serialization;

namespace QuakeLogParser.Domain.Entities
{
    public class ReportGame:IGame    
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        [JsonIgnore]
        public string Name { get; set; }
        public int Total_Kills { get; set; }
        public List<string> Players { get; set; }
        public Dictionary<string, int> Kills { get; set; }
        public Dictionary<string, int> Kills_By_Means { get; set; }
        
    }
}
