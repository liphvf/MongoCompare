using System;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace M101N
{
    public class Log
    {
        [BsonId]
        public MongoDB.Bson.ObjectId _id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Double TimeDifference { get; set; }
        public String Msg { get; set; }
        public String Operation { get; set; }     
    }
}
