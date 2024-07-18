using BidCalculationTool.Enums;
using Newtonsoft;
using Newtonsoft.Json;

namespace BidCalculationTool.Models
{
    public class Vehicle
    {

        public double VehiclePrice { get; set; }

        public string VehicleType { get; set; }

        [JsonProperty("Basic")]
        public double BasicBuyerFee { get; set; }

        [JsonProperty("Special")]
        public double SellerSpecialFee { get; set; }

        [JsonProperty("Association")]
        public double AssociationFee{ get; set; }

        //Since Storage fee is fixed no need of setter
        [JsonProperty("Storage")]
        public int StorageFee => 100;

        public double Total => VehiclePrice + BasicBuyerFee + SellerSpecialFee + AssociationFee + StorageFee;

    }
}
