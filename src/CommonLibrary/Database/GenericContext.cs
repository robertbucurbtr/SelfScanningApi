using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CommonLibrary.Database
{
    public class GenericContext<T> : IGenericContext<T> where T : BaseClass
    {
        private readonly IMongoDatabase db;
        private List<CollectionMongoDb<T>> entities;
        public GenericContext(IOptions<Settings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            db = client.GetDatabase(options.Value.Database);
            entities = new List<CollectionMongoDb<T>>();
            options.Value.CollectionsName.ForEach(collection =>
            entities.Add(
                new CollectionMongoDb<T>
                {
                    Name = collection,
                    Collection = db.GetCollection<T>(collection)
                }));
        }
        public IMongoCollection<T> this[string index]      
        {
            get
            {
                return entities.FirstOrDefault(collection => collection.Name == index)?.Collection;
            }
        }

    }
}
