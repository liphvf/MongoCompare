using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;

namespace M101N
{
    class Program
    {

        public static void Main(string[] args)
        {
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddTransient<Database>()
                .AddTransient<Log>()
                .AddTransient<Test>()
                .BuildServiceProvider();

            //configure console logging
            serviceProvider
                .GetService<ILoggerFactory>()
                .AddConsole(LogLevel.Debug);

            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();
            logger.LogDebug("Starting application");

            logger.LogDebug("All done!");

            var test = serviceProvider.GetService<Test>();

            test.PrimeiraBateria().GetAwaiter().GetResult();
        }
    }
}
