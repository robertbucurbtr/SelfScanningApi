using CommonLibrary.Database;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApi.Dto
{
    public class Customer : BaseClass
    {
        [BsonElement]
        public string CustomerName { get; set; }
    }
}
