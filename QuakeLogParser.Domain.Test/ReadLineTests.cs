using Xunit;
using Moq;
using QuakeLogParser.Domain.Services;
using QuakeLogParser.Domain.Services.Interface;
using QuakeLogParser.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuakeLogParser.Tests
{
    public class ReadLineTests
    {
        [Fact]
        public async Task ReadKillTest()
        {
            // Arrange
            var mockReadMatch = new Mock<IReadMatch>();
            var readLine = new ReadLine(mockReadMatch.Object);
            var line = "Kill: 1022 2 22: <world> killed Isgalamido by MOD_TRIGGER_HURT";
            var game = new Game { GameMatchs = new List<GameMatch>() };
            var gameMatches = new List<GameMatch> { new GameMatch(), new GameMatch() };

            // Mock GetInfoPlayers to return predefined gameMatches
            mockReadMatch.Setup(r => r.GetInfoPlayers(It.IsAny<string>())).Returns(Task.FromResult(gameMatches));

            // Act
            var result = await readLine.ReadKill(line, game);

            // Assert
            Assert.Equal(gameMatches.Count, result.GameMatchs.Count);
        }

        [Fact]
        public async Task ReadInitGameTest()
        {
            // Arrange
            var mockReadMatch = new Mock<IReadMatch>();
            var readLine = new ReadLine(mockReadMatch.Object);
            var line = "InitGame: \\sv_floodProtect\\1\\sv_maxPing\\0";
            var games = new List<Game>();

            // Act
            var result = await readLine.ReadInitGame(line, games);

            // Assert
            Assert.NotNull(result);
            Assert.Equal($"Game_{games.Count + 1}", result.Name);
        }
    }
}
