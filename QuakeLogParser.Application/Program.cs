using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QuakeLogParser.Infrastructure;
using System.Configuration;

namespace QuakeLogParser.App
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            ApplicationConfiguration.Initialize();

            var host = Setup.CreateHostBuilder()
                .CreateFormBuilder<Form1>()
                .Build();            

            Application.Run(host.Services.GetRequiredService<Form1>());

        }
    }
}