using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApi.Database
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<Customer> GetCustomer(string customerId);
        Task Create(Customer customer);
        Task<bool> Update(Customer customer);
        Task<bool> Delete(string name);
    }
}

