using ASPNETCoreInvoice.Models;
using ASPNETCoreInvoice.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCoreInvoice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IRepository<Customer> _customerRepository;
        private CustomerDbContext _context;
        public CustomerController(IRepository<Customer> customerRepository, CustomerDbContext context)
        {
            _customerRepository = customerRepository;
            _context = context; 
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomersAsync()
        {
            var allCustomers = await _customerRepository.GetAllAsync();
            return Ok(allCustomers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomerById(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            await _customerRepository.AddAsync(customer);
            //return Ok(Customer);
            return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCustomerById(int Id)
        {
            await _customerRepository.DeleteAsync(Id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Customer>> UpdateCustomerAsync(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            await _customerRepository.UpdateAsync(customer);
            _customerRepository.ToString();
            //return Ok(Customer);
            return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);
        }


    }
}
