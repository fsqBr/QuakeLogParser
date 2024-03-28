using QuakeLogParser.Domain.Entities;

namespace QuakeLogParser.Domain.Services.Interface
{
    public interface IParser
    {
        Task<List<Game>> Read(string log);
    }
}
