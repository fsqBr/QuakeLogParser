using QuakeLogParser.Domain.Entities;
using Xunit;
using System;
using System.Collections.Generic;

namespace QuakeLogParser.Domain.Test
{
    public class GameTests
    {
        [Fact]
        public void GameCreationTest()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = "Test Game";
            var gameMatches = new List<GameMatch>();

            // Act
            var game = new Game
            {
                Id = id,
                Name = name,
                GameMatchs = gameMatches
            };

            // Assert
            Assert.Equal(id, game.Id);
            Assert.Equal(name, game.Name);
            Assert.Equal(gameMatches, game.GameMatchs);
        }
    }
}
