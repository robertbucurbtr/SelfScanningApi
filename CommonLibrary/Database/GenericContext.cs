using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CommonLibrary.Database
{
    public class GenericContext<T> : IGenericContext<T> where T : BaseClass
    {
        private readonly IMongoDatabase db;
        public GenericContext(IOptions<Settings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            db = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<T> Entities => db.GetCollection<T>("Entities");
    }
}
