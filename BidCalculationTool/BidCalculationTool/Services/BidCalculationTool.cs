using BidCalculationTool.Constants;
using BidCalculationTool.Enums;
using BidCalculationTool.Helpers;
using BidCalculationTool.Interface;

namespace BidCalculationTool.Services
{
    public class BidCalculationTool : IBidCalculationTool
    {
        public double CalculateBuyersFee(double vehiclePrice, VehicleType vehicleType)
        {
            var buyersFee = 0.0;
            //10% of the price of the vehicle
            var fee = (vehiclePrice * 10) / 100;

            switch (vehicleType)
            {
                //For Common type minimum $10
                case VehicleType.Common:
                    if (fee < BidCalculationConstant.BUYERSFEE_COMMON_MINIMUM_VALUE)
                    {
                        return 10; ;
                    }
                //For Common type maximum $50
                    else if (fee > BidCalculationConstant.BUYERSFEE_COMMON_MAXIMUM_VALUE)
                    {
                        return 50;
                    }
                    buyersFee = fee;
                    break;

                case VehicleType.Luxury:
                    //For Luxury type minimum $25
                    if (fee < BidCalculationConstant.BUYERSFEE_LUXURY_MINIMUM_VALUE)
                    {
                        return 25;
                    }
                    //For Luxury type maximum $200
                    else if (fee > BidCalculationConstant.BUYERSFEE_LUXURY_MAXIMUM_VALUE)
                    {
                        return 200;
                    }
                    buyersFee = fee;
                    break;
            }

            return buyersFee;
        }

        public double CalculateSellerFee(double vehiclePrice, VehicleType vehicleType)
        {
            switch (vehicleType)
            {
                //For Common Type 2% of the vehicle pric
                case VehicleType.Common:
                    var commonFee = (vehiclePrice * BidCalculationConstant.SELLERSFEE_COMMON_PERCENTAGE) / 100;
                    return commonFee;
                //For Luxury Type 4% of the vehicle pric
                case VehicleType.Luxury:
                    var luxuryFee = (vehiclePrice * BidCalculationConstant.SELLERSFEE_LUXURY_PERCENTAGE) / 100;
                    return luxuryFee;
                default: return 0.0;
            }
        }

        public int AssociationFee(double vehiclePrice)
        {
            var associationFee = RangeChecker.GetAssociationFee(vehiclePrice);
            return associationFee;
        }
    }
}
