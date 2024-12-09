using EnocaChallange.Models;
using EnocaChallange.Services;
using Microsoft.AspNetCore.Mvc;

namespace EnocaChallange.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierController : ControllerBase
    {
        private readonly ICarrierService _carrierService;

        public CarrierController(ICarrierService carrierService)
        {
            _carrierService = carrierService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carrier>>> GetCarriers()
        {
            var carriers = await _carrierService.GetAllCarriersAsync();
            return Ok(carriers);
        }

        [HttpPost]
        public async Task<ActionResult<Carrier>> PostCarrier(Carrier carrier)
        {
           
            await _carrierService.AddCarrierAsync(carrier);

            
            return Ok($"Kargo firması başarıyla eklendi. Carrier ID: {carrier.CarrierId}");
        }


        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarrier(int id, Carrier carrier)
        {
            if (id != carrier.CarrierId)
            {
                return BadRequest();
            }

            await _carrierService.UpdateCarrierAsync(carrier);

            
            return Ok($"Kargo bilgileri güncellendi. Carrier ID: {carrier.CarrierId}");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarrier(int id)
        {
            
            await _carrierService.DeleteCarrierAsync(id);

            
            return Ok($"Kargo firması başarıyla silindi. Carrier ID: {id}");
        }

    }
}
