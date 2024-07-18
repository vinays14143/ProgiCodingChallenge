using BidCalculationTool.Enums;

namespace BidCalculationTool.Interface
{
    public interface IBidCalculationTool
    {
        public double CalculateBuyersFee(double vehiclePrice, VehicleType vehicleType);
        public double CalculateSellerFee(double vehiclePrice, VehicleType vehicleType);
        public int AssociationFee(double vehiclePrice);

    }
}
