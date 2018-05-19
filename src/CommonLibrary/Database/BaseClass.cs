using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.Database
{
    public class BaseClass
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement]
        public string EntityId { get; set; }
    }
}
