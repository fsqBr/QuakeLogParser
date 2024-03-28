using System.Text.Json.Serialization;

namespace QuakeLogParser.Domain.Entities
{
    public interface IGame
    {
        Guid Id { get; set; }

        string Name { get; set; }

    }
}
