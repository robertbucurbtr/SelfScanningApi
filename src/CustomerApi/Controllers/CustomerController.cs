using System.Threading.Tasks;
using CommonLibrary.Database;
using CustomerApi.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerApi.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly IGenericRepository<Customer> customerRepository;
        public CustomerController(IGenericRepository<Customer> customerRepository)
        {
            this.customerRepository = customerRepository;
            this.customerRepository.SetCollection("Customers");
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await customerRepository.GetAll();
            return Ok(result);
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> Get(string customerId)
        {
            var result = await customerRepository.GetById(customerId);
            if (result == null) return NotFound();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Customer customer)
        {
            await customerRepository.Create(customer);
            return Ok(customer);
        }

    }
}
