using Xunit;
using Microsoft.Extensions.DependencyInjection;
using QuakeLogParser.Domain.Services.Interface;
using QuakeLogParser.Infrastructure;
using Microsoft.Extensions.Hosting;
using QuakeLogParser.Domain.Services;

namespace QuakeLogParser.Tests
{
    public class SetupTests
    {
        [Fact]
        public void CreateHostBuilder_RegistersServicesCorrectly()
        {
            // Arrange
            var hostBuilder = Setup.CreateHostBuilder();

            // Act
            var host = hostBuilder.Build();
            var services = host.Services;

            // Assert
            Assert.NotNull(services.GetService<IParser>());
            Assert.NotNull(services.GetService<IReadLine>());
            Assert.NotNull(services.GetService<IReadMatch>());
            Assert.NotNull(services.GetService<IReportMatch>());
            Assert.NotNull(services.GetService<IResolveJson>());
        }

       


    }
}
