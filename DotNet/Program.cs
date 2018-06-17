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

            //do the actual work here
            // var bar = serviceProvider.GetService<IBarService>();
            // bar.DoSomeRealWork();

            logger.LogDebug("All done!");

            var test = serviceProvider.GetService<Test>();

            test.PrimeiraBateria().GetAwaiter().GetResult();

        }
        // static void Main(string[] args)
        // {
        //     MainAsync(args).GetAwaiter().GetResult();
        //     Console.WriteLine();
        //     Console.WriteLine("Precisone enter");
        //     Console.WriteLine();

        // }
        // static async Task MainAsync(string[] args)
        // {
        //     var connectionString = "mongodb://localhost:27017";
        //     var client = new MongoClient(connectionString);
        //     var db = client.GetDatabase("dotnet");
        //     var col = db.GetCollection<BsonDocument>("people");


        // }
    }
}
