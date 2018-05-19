using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CustomerApi.Database
{
    public class CustomerContext:ICustomerContext
    {
        private readonly IMongoDatabase db;

        public CustomerContext(IOptions<Settings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            db = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<Customer> Customers => db.GetCollection<Customer>("Customers");
    }
}
