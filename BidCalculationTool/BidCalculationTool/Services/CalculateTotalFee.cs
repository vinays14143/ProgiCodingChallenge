using BidCalculationTool.Enums;
using BidCalculationTool.Interface;
using BidCalculationTool.Models;

namespace BidCalculationTool.Services
{
    public class CalculateTotalFee : ICalculateTotalFee
    {
        private readonly IBidCalculationTool _billCalculationTool;

        public CalculateTotalFee(IBidCalculationTool billCalculationTool)
        {
            _billCalculationTool = billCalculationTool;
        }

        //To get the total price of the vehicle based various fees
        public Vehicle CalculateTotalVehicleFee(double vehiclePrice, VehicleType vehicleType)
        {
            var basicFee = _billCalculationTool.CalculateBuyersFee(vehiclePrice, vehicleType);
            var sellerFee = _billCalculationTool.CalculateSellerFee(vehiclePrice, vehicleType);
            var associationFee = _billCalculationTool.AssociationFee(vehiclePrice);
            return new Vehicle
            {
                VehiclePrice = vehiclePrice,
                BasicBuyerFee = basicFee,
                AssociationFee = associationFee,
                SellerSpecialFee = sellerFee,
                VehicleType = vehicleType.ToString()
            };
        }
    }
}
