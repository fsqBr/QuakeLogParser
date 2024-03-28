using Xunit;
using QuakeLogParser.Domain.Services;
using QuakeLogParser.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuakeLogParser.Tests
{
    public class ResolveJsonTests
    {
        [Fact]
        public async Task ReturnJsonTest()
        {
            // Arrange
            var resolveJson = new ResolveJson();
            var lsGames = new List<Game>
            {
                new Game { Name = "game_1", Id = Guid.NewGuid() },
                new Game { Name = "game_2", Id = Guid.NewGuid() }
            };

            // Act
            var result = await resolveJson.ReturnJson(lsGames);

            // Assert
            Assert.Contains("\"game_1\":", result);
            Assert.Contains("\"game_2\":", result);
        }
    }
}
