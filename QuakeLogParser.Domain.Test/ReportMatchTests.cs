using Xunit;
using QuakeLogParser.Domain.Services;
using QuakeLogParser.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QuakeLogParser.Domain;

namespace QuakeLogParser.Tests
{
    public class ReportMatchTests
    {
        [Fact]
        public async Task GetPlayersStatsTest()
        {
            // Arrange
            var reportMatch = new ReportMatch();
            var players = new List<string> { "Player1", "Player2" };
            var gameMatches = new List<GameMatch>
            {
                new GameMatch { Player = "Player1", Action = TypeActionEnum.Kill },
                new GameMatch { Player = "Player2", Action = TypeActionEnum.Death }
            };

            // Act
            var result = await reportMatch.GetPlayersStats(players, gameMatches);

            // Assert
            Assert.Equal(players.Count, result.Count);
            Assert.Contains("Player1", result.Keys);
            Assert.Contains("Player2", result.Keys);
        }

        [Fact]
        public async Task GetWeaponStatsTest()
        {
            // Arrange
            var reportMatch = new ReportMatch();
            var gameMatches = new List<GameMatch>
            {
                new GameMatch { Weppon = "MOD_SHOTGUN" },
                new GameMatch { Weppon = "MOD_ROCKET" }
            };

            // Act
            var result = await reportMatch.GetWeaponStats(gameMatches);

            // Assert
            Assert.Equal(gameMatches.Select(g => g.Weppon).Distinct().Count(), result.Count);
            Assert.Contains("MOD_SHOTGUN", result.Keys);
            Assert.Contains("MOD_ROCKET", result.Keys);
        }

        [Fact]
        public async Task GroupedMatchTest()
        {
            // Arrange
            var reportMatch = new ReportMatch();
            var games = new List<Game>
            {
                new Game
                {
                    Id = Guid.NewGuid(),
                    GameMatchs = new List<GameMatch>
                    {
                        new GameMatch { Player = "Player1", Action = TypeActionEnum.Kill, IsPlayer = true },
                        new GameMatch { Player = "Player2", Action = TypeActionEnum.Death , IsPlayer = true }
                    }
                },
                new Game
                {
                    Id = Guid.NewGuid(),
                    GameMatchs = new List<GameMatch>
                    {
                        new GameMatch { Player = "Player3", Action = TypeActionEnum.Kill , IsPlayer = true },
                        new GameMatch { Player = "Player4", Action = TypeActionEnum.Death, IsPlayer = true  }
                    }
                }
            };

            // Act
            var result = await reportMatch.GroupedMatch(games, true);

            // Assert
            Assert.Equal(games.Count, result.Count);
            for (int i = 0; i < result.Count; i++)
            {
                Assert.Equal(games[i].Id, result[i].Id);
                Assert.Equal(games[i].GameMatchs.Count(g => g.Action == TypeActionEnum.Kill), result[i].Total_Kills);
                Assert.Equal(games[i].GameMatchs.Where(x => x.IsPlayer == true).Select(x => x.Player).Distinct().Count(), result[i].Players.Count);
                Assert.Equal($"game_{i + 1}", result[i].Name);
            }
        }
    }
}
