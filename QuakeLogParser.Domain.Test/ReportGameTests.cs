using Xunit;
using QuakeLogParser.Domain.Entities;
using System;
using System.Collections.Generic;

namespace QuakeLogParser.Tests
{
    public class ReportGameTests
    {
        [Fact]
        public void ReportGameCreationTest()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = "Test Game";
            var totalKills = 10;
            var players = new List<string> { "Player1", "Player2" };
            var kills = new Dictionary<string, int> { { "Player1", 5 }, { "Player2", 5 } };
            var killsByMeans = new Dictionary<string, int> { { "MOD_SHOTGUN", 10 } };

            // Act
            var reportGame = new ReportGame
            {
                Id = id,
                Name = name,
                Total_Kills = totalKills,
                Players = players,
                Kills = kills,
                Kills_By_Means = killsByMeans
            };

            // Assert
            Assert.Equal(id, reportGame.Id);
            Assert.Equal(name, reportGame.Name);
            Assert.Equal(totalKills, reportGame.Total_Kills);
            Assert.Equal(players, reportGame.Players);
            Assert.Equal(kills, reportGame.Kills);
            Assert.Equal(killsByMeans, reportGame.Kills_By_Means);
        }
    }
}
