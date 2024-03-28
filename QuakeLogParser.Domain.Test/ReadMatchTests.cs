using Xunit;
using QuakeLogParser.Domain.Services;
using QuakeLogParser.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QuakeLogParser.Domain;

namespace QuakeLogParser.Tests
{
    public class ReadMatchTests
    {
        [Fact]
        public async Task GetInfoPlayersTest()
        {
            // Arrange
            var readMatch = new ReadMatch();
            var lineMatch = "20:34 Kill: 1022 2 22: <world> killed Isgalamido by MOD_TRIGGER_HURT";

            // Act
            var result = await readMatch.GetInfoPlayers(lineMatch);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Contains(result, r => r.Player == "<world>" && r.Action == TypeActionEnum.Kill);
            Assert.Contains(result, r => r.Player == "Isgalamido" && r.Action == TypeActionEnum.Death);
        }

        [Fact]
        public async Task GetWeaponTest()
        {
            // Arrange
            var readMatch = new ReadMatch();
            var lineMatch = "20:34 Kill: 1022 2 22: <world> killed Isgalamido by MOD_TRIGGER_HURT";

            // Act
            var result = await readMatch.GetWeapon(lineMatch);

            // Assert
            Assert.Equal("MOD_TRIGGER_HURT", result);
        }
    }
}
