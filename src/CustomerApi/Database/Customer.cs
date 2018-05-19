using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApi.Database
{
    public class Customer
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement]
        public string CustomerId { get; set; }
        [BsonElement]
        public string CustomerName { get; set; }
    }
}
