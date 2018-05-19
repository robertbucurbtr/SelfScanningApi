using MongoDB.Driver;

namespace CustomerApi.Database
{
    public interface ICustomerContext
    {
        IMongoCollection<Customer> Customers { get; }
    }
}