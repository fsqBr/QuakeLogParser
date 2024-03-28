using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QuakeLogParser.Domain.Services;
using QuakeLogParser.Domain.Services.Interface;
using System;

namespace QuakeLogParser.Infrastructure
{
  
    public static class Setup
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        public static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<IParser, Parser>();
                    services.AddTransient<IReadLine, ReadLine>();
                    services.AddTransient<IReadMatch, ReadMatch>();
                    services.AddTransient<IReportMatch, ReportMatch>(); 
                    services.AddTransient<IResolveJson, ResolveJson>();
                });
        }

        public static IHostBuilder CreateFormBuilder<T>(this IHostBuilder hostBuilder) where T : class
        {
            return hostBuilder
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<T>();
                });
        }
    }
}
