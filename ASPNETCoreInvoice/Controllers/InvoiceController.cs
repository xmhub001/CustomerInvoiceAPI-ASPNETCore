using ASPNETCoreInvoice.Models;
using ASPNETCoreInvoice.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCoreInvoice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceRepository _invoiceRepository;
        public InvoiceController(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetAllInvoicesAsync()
        {
            var allInvoices = await _invoiceRepository.GetAllInvoicesAsync();
            return Ok(allInvoices);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetInvoiceById(int id)
        {
            var invoice = await _invoiceRepository.GetInvoiceByIdAsync(id);
            if (invoice == null) {
                return NotFound();
            }
            return Ok(invoice);
        }

        [HttpPost]
        public async Task<ActionResult<Invoice>> CreateInvoice(Invoice invoice)
        {
            if (ModelState.IsValid == false) { 
                return BadRequest(ModelState);
            }
            await _invoiceRepository.AddInvoiceAsync(invoice);
            //return Ok(invoice);
            return CreatedAtAction(nameof(GetInvoiceById), new {id = invoice.Id}, invoice);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteInvoiceById(int Id)
        {
            await _invoiceRepository.DeleteInvoiceAsync(Id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Invoice>> UpdateInvoiceAsync(int id, Invoice invoice)
        {
            if (id != invoice.Id) { 
                return BadRequest();
            }
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            await _invoiceRepository.UpdateInvoiceAsync(invoice);
            //return Ok(invoice);
            return CreatedAtAction(nameof(GetInvoiceById), new { id = invoice.Id }, invoice);
        }    
    }
}
