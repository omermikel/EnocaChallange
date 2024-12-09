using System.Text.Json.Serialization;

namespace EnocaChallange.Models
{
    public class Carrier
    {
        public int CarrierId { get; set; }  
        public string CarrierName { get; set; }
        public bool CarrierIsActive { get; set; }
        public decimal CarrierPlusDesiCost { get; set; }

        public ICollection<CarrierConfiguration> CarrierConfigurations { get; set; }
    }
}
