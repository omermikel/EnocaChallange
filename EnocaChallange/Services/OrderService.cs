using EnocaChallange.Models;
using EnocaChallange.Repositories;

namespace EnocaChallange.Services
{
    public class OrderService
    {
        private readonly IRepository<CarrierConfiguration> _carrierConfigRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Carrier> _carrierRepository;  

        
        public OrderService(IRepository<CarrierConfiguration> carrierConfigRepository,
                            IRepository<Order> orderRepository,
                            IRepository<Carrier> carrierRepository)
        {
            _carrierConfigRepository = carrierConfigRepository;
            _orderRepository = orderRepository;
            _carrierRepository = carrierRepository; 
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _orderRepository.GetByIdAsync(id);
        }

        public async Task<string> AddOrderAsync(Order order)
        {
            
            var carrierConfigs = await _carrierConfigRepository.GetAllAsync();
            var carriers = await _carrierRepository.GetAllAsync();

            
            var matchingConfigs = carrierConfigs
                .Where(cc => order.OrderDesi >= cc.CarrierMinDesi && order.OrderDesi <= cc.CarrierMaxDesi)
                .OrderBy(cc => cc.CarrierCost)
                .ToList();

            decimal bestCost = decimal.MaxValue;
            Carrier bestCarrier = null;

            if (matchingConfigs.Any())
            {
                
                foreach (var config in matchingConfigs)
                {
                    var carrier = carriers.FirstOrDefault(c => c.CarrierId == config.CarrierId);
                    if (carrier == null)
                    {
                        throw new Exception($"Carrier with ID {config.CarrierId} not found.");
                    }

                    decimal totalCost = config.CarrierCost;

                    
                    if (totalCost < bestCost)
                    {
                        bestCost = totalCost;
                        bestCarrier = carrier;
                    }
                }

                
                if (bestCarrier != null)
                {
                    order.OrderCarrierCost = bestCost;
                    order.CarrierId = bestCarrier.CarrierId;
                }
            }
            else
            {
                
                var nearestConfig = carrierConfigs
                    .OrderBy(cc => Math.Abs(order.OrderDesi - cc.CarrierMaxDesi))
                    .ToList();

                foreach (var config in nearestConfig)
                {
                    var carrier = carriers.FirstOrDefault(c => c.CarrierId == config.CarrierId);
                    if (carrier == null)
                    {
                        throw new Exception($"Carrier with ID {config.CarrierId} not found.");
                    }

                    
                    int desiFark = Math.Max(0, order.OrderDesi - config.CarrierMaxDesi);
                    decimal ekUcret = desiFark * carrier.CarrierPlusDesiCost;

                    
                    decimal totalCost = config.CarrierCost + ekUcret;

                    
                    if (totalCost < bestCost)
                    {
                        bestCost = totalCost;
                        bestCarrier = carrier;
                    }
                }

                
                if (bestCarrier != null)
                {
                    order.OrderCarrierCost = bestCost;
                    order.CarrierId = bestCarrier.CarrierId;
                }
            }

            if (bestCarrier == null)
            {
                throw new Exception("No suitable carrier found.");
            }

            
            await _orderRepository.AddAsync(order);

            return $"{order.OrderId} ID’li sipariş {bestCarrier.CarrierId} ID'li firmaya {bestCost} TL fiyatıyla başarıyla eklendi."; 
        }

        public async Task<string> DeleteOrderAsync(int id)
        {
            await _orderRepository.DeleteAsync(id);
            return $"{id} ID’li sipariş silindi";  
        }
    }
}
