using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApi.Database
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly ICustomerContext _context;

        public CustomerRepository(ICustomerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _context
                            .Customers
                            .Find(_ => true)
                            .ToListAsync();
        }

        public Task<Customer> GetCustomer(string customerId)
        {
            FilterDefinition<Customer> filter = Builders<Customer>.Filter.Eq(m => m.CustomerId, customerId);
             
            return _context
                    .Customers
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }

        public async Task Create(Customer customer)
        {
            await _context.Customers.InsertOneAsync(customer);
        }

        public async Task<bool> Update(Customer customer)
        {
            ReplaceOneResult updateResult =
                await _context
                        .Customers
                        .ReplaceOneAsync(
                            filter: g => g.Id == customer.Id,
                            replacement: customer);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(string name)
        {
            FilterDefinition<Customer> filter = Builders<Customer>.Filter.Eq(m => m.CustomerName, name);

            DeleteResult deleteResult = await _context
                                                .Customers
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
    }
}
