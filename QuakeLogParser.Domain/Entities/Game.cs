namespace QuakeLogParser.Domain.Entities
{
    public class Game: IGame
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<GameMatch> GameMatchs { get; set; }
        
    }

}
