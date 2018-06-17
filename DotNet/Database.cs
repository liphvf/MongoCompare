using System;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace M101N
{
    public class Database
    {
        public Database()
        {
            ConnectionString = "mongodb://localhost:27017";
            DatabaseName = "DotNet";
            Application = Instance();
            Log = Instance(true);
        }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        public IMongoDatabase Application { get; set; }
        public IMongoDatabase Log { get; set; }

        public IMongoDatabase Instance(bool Log = false)
        {
            var client = new MongoClient(ConnectionString);
            if (Log)
            {
                return client.GetDatabase("Log");
            }
            return client.GetDatabase(DatabaseName);
        }

        public async Task RegistrarLog(DateTime start, DateTime end, String msg = "", String operation = "")
        {
            var col = Log.GetCollection<Log>("DotNet");

            var timeDifference = (end - start).TotalMilliseconds;

            await col.InsertOneAsync(new Log
            {
                Start = start,
                End = end,
                TimeDifference = Math.Round(timeDifference, 2),
                Msg = msg,
                Operation = operation
            });
        }
    }
}