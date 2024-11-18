using ASPNETCoreInvoice.Models;
using ASPNETCoreInvoice.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCoreInvoice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly IRepository<Bill> _billRepository;
        public BillController(IRepository<Bill> billRepository)
        {
            _billRepository = billRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bill>>> GetAllBillsAsync()
        {
            var allBills = await _billRepository.GetAllAsync();
            return Ok(allBills);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Bill>>> GetBillById(int id)
        {
            var bill = await _billRepository.GetByIdAsync(id);
            if (bill == null)
            {
                return NotFound();
            }
            return Ok(bill);
        }

        [HttpPost]
        public async Task<ActionResult<Bill>> CreateBill(Bill bill)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            await _billRepository.AddAsync(bill);
            //return Ok(Bill);
            return CreatedAtAction(nameof(GetBillById), new { id = bill.Id }, bill);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteBillById(int Id)
        {
            await _billRepository.DeleteAsync(Id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Bill>> UpdateBillAsync(int id, Bill bill)
        {
            if (id != bill.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            await _billRepository.UpdateAsync(bill);
            //return Ok(Bill);
            return CreatedAtAction(nameof(GetBillById), new { id = bill.Id }, bill);
        }

    }
}
