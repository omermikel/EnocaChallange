using EnocaChallange.Models;
using EnocaChallange.Services;
using Microsoft.AspNetCore.Mvc;

namespace EnocaChallange.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }

        
        [HttpPost]
        public async Task<ActionResult<string>> PostOrder(Order order)
        {
            var resultMessage = await _orderService.AddOrderAsync(order);
            return Ok(resultMessage);  
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteOrder(int id)
        {
            var resultMessage = await _orderService.DeleteOrderAsync(id);
            return Ok(resultMessage);  
        }
    }
}
