﻿using CommonLibrary.Database;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApi.Database
{
    public class Customer:BaseClass
    {
        [BsonElement]
        public string CustomerName { get; set; }
    }
}
