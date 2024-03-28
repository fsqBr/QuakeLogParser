using Xunit;
using QuakeLogParser.Domain.Entities;
using System;
using QuakeLogParser.Domain;

namespace QuakeLogParser.Tests
{
    public class GameMatchTests
    {
        [Fact]
        public void GameMatchCreationTest()
        {
            // Arrange
            var id = Guid.NewGuid();
            var player = "Test Player";
            var action = TypeActionEnum.Death; // Replace with your actual enum value
            var weapon = "Test Weapon";
            var isPlayer = true;

            // Act
            var gameMatch = new GameMatch
            {
                Id = id,
                Player = player,
                Action = action,
                Weppon = weapon,
                IsPlayer = isPlayer
            };

            // Assert
            Assert.Equal(id, gameMatch.Id);
            Assert.Equal(player, gameMatch.Player);
            Assert.Equal(action, gameMatch.Action);
            Assert.Equal(weapon, gameMatch.Weppon);
            Assert.Equal(isPlayer, gameMatch.IsPlayer);
        }
    }
}
