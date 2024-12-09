using EnocaChallange.Models;
using EnocaChallange.Services;
using Microsoft.AspNetCore.Mvc;

namespace EnocaChallange.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierConfigurationController : ControllerBase
    {
        private readonly ICarrierConfigurationService _carrierConfigService;

        public CarrierConfigurationController(ICarrierConfigurationService carrierConfigService)
        {
            _carrierConfigService = carrierConfigService;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarrierConfiguration>>> GetCarrierConfigurations()
        {
            var configurations = await _carrierConfigService.GetAllCarrierConfigurationsAsync();
            return Ok(configurations);
        }

        [HttpPost]
        public async Task<ActionResult<CarrierConfiguration>> PostCarrierConfiguration(CarrierConfiguration configuration)
        {
            // Kargo konfigürasyonunu ekle
            await _carrierConfigService.AddCarrierConfigurationAsync(configuration);

            // Başarı mesajı döndür
            return Ok($"Kargo konfigürasyonu başarıyla eklendi. Kargo Konfigürasyon ID: {configuration.CarrierConfigurationId}");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarrierConfiguration(int id, CarrierConfiguration configuration)
        {
            if (id != configuration.CarrierConfigurationId)
            {
                return BadRequest();
            }

            await _carrierConfigService.UpdateCarrierConfigurationAsync(configuration);
            return Ok($"Kargo konfigürasyonu bilgileri güncellendi. Kargo Konfügürasyon ID: {configuration.CarrierConfigurationId}");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarrierConfiguration(int id)
        {
            await _carrierConfigService.DeleteCarrierConfigurationAsync(id);
            return Ok($"Kargo konfigürasyonu ID {id} başarıyla silindi.");
        }
    }
}
