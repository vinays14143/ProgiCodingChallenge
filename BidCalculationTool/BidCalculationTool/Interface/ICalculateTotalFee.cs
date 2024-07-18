using BidCalculationTool.Enums;
using BidCalculationTool.Models;

namespace BidCalculationTool.Interface
{
    public interface ICalculateTotalFee
    {
        public Vehicle CalculateTotalVehicleFee(double vehiclePrice, VehicleType vehicleType);
    }
}
