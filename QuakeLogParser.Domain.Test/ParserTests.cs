using Xunit;
using Moq;
using QuakeLogParser.Domain.Services;
using QuakeLogParser.Domain.Services.Interface;
using QuakeLogParser.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;

namespace QuakeLogParser.Tests
{
    public class ParserTests
    {
        [Fact]
        public async Task ReadTest()
        {
            // Arrange
            var mockReadLine = new Mock<IReadLine>();
            var parser = new Parser(mockReadLine.Object);
            var log = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test.log");

            // Create a test log file
            File.WriteAllLines(log, new[] { "InitGame", "Kill: Player1 killed Player2" });

            // Setup mock
            mockReadLine.Setup(x => x.ReadInitGame(It.Is<string>(s => s.Contains("InitGame")), It.IsAny<List<Game>>()))
                .Returns(Task.FromResult(new Game { Id = Guid.NewGuid() }));
            mockReadLine.Setup(x => x.ReadKill(It.IsAny<string>(), It.IsAny<Game>()));

            // Act
            var result = await parser.Read(log);

            // Assert
            Assert.Single(result);
            mockReadLine.Verify(x => x.ReadInitGame(It.Is<string>(s => s.Contains("InitGame")), It.IsAny<List<Game>>()), Times.Once);
            mockReadLine.Verify(x => x.ReadKill(It.IsAny<string>(), It.IsAny<Game>()), Times.Once);

            // Cleanup
            File.Delete(log);

        }
    }
}
