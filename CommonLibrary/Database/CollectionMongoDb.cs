using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.Database
{
    public class CollectionMongoDb<T> where T:BaseClass
    {
        public string Name { get; set; }
        public IMongoCollection<T> Collection { get; set; }
    }
}
