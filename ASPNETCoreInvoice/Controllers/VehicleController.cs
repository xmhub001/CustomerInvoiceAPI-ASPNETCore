using ASPNETCoreInvoice.Models;
using ASPNETCoreInvoice.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCoreInvoice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IRepository<Vehicle> _vehicleRepository;
        public VehicleController(IRepository<Vehicle> vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetAllVehiclesAsync()
        {
            var allVehicles = await _vehicleRepository.GetAllAsync();
            return Ok(allVehicles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicleById(int id)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return Ok(vehicle);
        }

        [HttpPost]
        public async Task<ActionResult<Vehicle>> CreateVehicle(Vehicle vehicle)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            await _vehicleRepository.AddAsync(vehicle);
            //return Ok(Vehicle);
            return CreatedAtAction(nameof(GetVehicleById), new { id = vehicle.Id }, vehicle);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteVehicleById(int Id)
        {
            await _vehicleRepository.DeleteAsync(Id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Vehicle>> UpdateVehicleAsync(int id, Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            await _vehicleRepository.UpdateAsync(vehicle);
            //return Ok(Vehicle);
            return CreatedAtAction(nameof(GetVehicleById), new { id = vehicle.Id }, vehicle);
        }
    }
}
