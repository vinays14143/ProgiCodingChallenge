using BidCalculationTool.Constants;
using BidCalculationTool.Enums;
using BidCalculationTool.Interface;
using BidCalculationTool.Services;
using Moq;
using NUnit.Framework.Legacy;
using System.Security.AccessControl;

namespace BidCalculationToolTest
{
    public class BillCalculationToolTest
    {

        private IBidCalculationTool _billCalculationTool;

        [SetUp]
        public void Setup()
        {
            _billCalculationTool = new BidCalculationTool.Services.BidCalculationTool();
        }

        [Test]
        public void Calculate_BuyersFee_For_Common_Type_For_MinimumValue()
        {
            //Arrange
            var vehiclePrice = 57;
            var vehicleType = VehicleType.Common;

            //Act
            var result = _billCalculationTool.CalculateBuyersFee(vehiclePrice, vehicleType);

            //Asert
            ClassicAssert.AreEqual(BidCalculationConstant.BUYERSFEE_COMMON_MINIMUM_VALUE, result);

        }

        [Test]
        public void Calculate_BuyersFee_For_Common_Type_For_MaximumValue()
        {
            //Arrange
            var vehiclePrice = 510;
            var vehicleType = VehicleType.Common;

            //Act
            var result = _billCalculationTool.CalculateBuyersFee(vehiclePrice, vehicleType);

            //Asert
            ClassicAssert.AreEqual(BidCalculationConstant.BUYERSFEE_COMMON_MAXIMUM_VALUE, result);

        }

        [Test]
        public void Calculate_BuyersFee_For_Common_Type_if_VehiclePrice_IS_INBetween_Minimum_Maximum_Price()
        {
            //Arrange
            var vehiclePrice = 398.00;
            var vehicleType = VehicleType.Common;
            var expectedValue = (double)((vehiclePrice * 10) / 100);

            //Act
            var result = _billCalculationTool.CalculateBuyersFee(vehiclePrice, vehicleType);

            //Asert
            ClassicAssert.AreEqual(expectedValue, result);

        }

        [Test]
        public void Calculate_BuyersFee_For_Luxury_Type_if_VehiclePrice_IS_INBetween_Minimum_Maximum_Price()
        {
            //Arrange
            var vehiclePrice = 1800;
            var vehicleType = VehicleType.Luxury;
            double expectedValue = (vehiclePrice * 10) / 100;

            //Act
            var result = _billCalculationTool.CalculateBuyersFee(vehiclePrice, vehicleType);

            //Asert
            ClassicAssert.AreEqual(expectedValue, result);

        }

        [Test]
        public void Calculate_BuyersFee_For_Luxury_Type_For_MinimumValue()
        {
            //Arrange
            var vehiclePrice = 57;
            var vehicleType = VehicleType.Luxury;

            //Act
            var result = _billCalculationTool.CalculateBuyersFee(vehiclePrice, vehicleType);

            //Asert
            ClassicAssert.AreEqual(BidCalculationConstant.BUYERSFEE_LUXURY_MINIMUM_VALUE, result);

        }

        [Test]
        public void Calculate_BuyersFee_For_Luxury_Type_For_MaximumValue()
        {
            //Arrange
            var vehiclePrice = 100000;
            var vehicleType = VehicleType.Luxury;

            //Act
            var result = _billCalculationTool.CalculateBuyersFee(vehiclePrice, vehicleType);

            //Asert
            ClassicAssert.AreEqual(BidCalculationConstant.BUYERSFEE_LUXURY_MAXIMUM_VALUE, result);

        }

        [Test]
        public void Calculate_SellersFee_For_Common_Type()
        {
            //Arrange
            var vehiclePrice = 100;
            var vehicleType = VehicleType.Common;
            var expectedValue = (vehiclePrice * BidCalculationConstant.SELLERSFEE_COMMON_PERCENTAGE) / 100;

            //Act
            var result = _billCalculationTool.CalculateSellerFee(vehiclePrice, vehicleType);

            //Asert
            ClassicAssert.AreEqual(expectedValue, result);

        }


        [Test]
        public void Calculate_SellersFee_For_Luxury_Type()
        {
            //Arrange
            var vehiclePrice = 500;
            var vehicleType = VehicleType.Luxury;
            var expectedValue = (vehiclePrice * BidCalculationConstant.SELLERSFEE_LUXURY_PERCENTAGE) / 100;

            //Act
            var result = _billCalculationTool.CalculateSellerFee(vehiclePrice, vehicleType);

            //Asert
            ClassicAssert.AreEqual(expectedValue, result);

        }


        [Test]
        public void Calculate_AssociationFee_For_VehiclePriceBetween_1_And_500()
        {
            //Arrange
            var vehiclePrice = 500;
            var expectedValue = 5;

            //Act
            var result = _billCalculationTool.AssociationFee(vehiclePrice);

            //Asert
            ClassicAssert.AreEqual(expectedValue, result);

        }

        [Test]
        public void Calculate_AssociationFee_For_VehiclePriceGreaterThen_500_And_Upto_1000()
        {
            //Arrange
            var vehiclePrice = 800;
            var expectedValue = 10;

            //Act
            var result = _billCalculationTool.AssociationFee(vehiclePrice);

            //Asert
            ClassicAssert.AreEqual(expectedValue, result);

        }

        [Test]
        public void Calculate_AssociationFee_For_VehiclePriceGreaterThen_1000_And_Upto_3000()
        {
            //Arrange
            var vehiclePrice = 2800;
            var expectedValue = 15;

            //Act
            var result = _billCalculationTool.AssociationFee(vehiclePrice);

            //Asert
            ClassicAssert.AreEqual(expectedValue, result);

        }

        [Test]
        public void Calculate_AssociationFee_For_VehiclePriceGreaterThen_3000()
        {
            //Arrange
            var vehiclePrice = 3100;
            var expectedValue = 20;

            //Act
            var result = _billCalculationTool.AssociationFee(vehiclePrice);

            //Asert
            ClassicAssert.AreEqual(expectedValue, result);

        }
    }
}