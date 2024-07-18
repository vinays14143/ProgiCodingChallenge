using BidCalculationTool.Constants;
using BidCalculationTool.Controllers;
using BidCalculationTool.Enums;
using BidCalculationTool.Interface;
using BidCalculationTool.Services;
using Moq;
using NUnit.Framework.Legacy;
using System.Security.AccessControl;

namespace BidCalculationToolTest
{
    public class CalculateTotalFeeUnitTest
    {

        private ICalculateTotalFee _calculateTotalFee;
        private IBidCalculationTool _bidCalculationTool;

        [SetUp]
        public void Setup()
        {
            _bidCalculationTool = new BidCalculationTool.Services.BidCalculationTool();
            _calculateTotalFee = new CalculateTotalFee(_bidCalculationTool);
        }

        [Test]
        public void Calculate_TotalVehile_For_Common_Type()
        {
            //Arrange
            var vehiclePrice = 57;
            var vehicleType = VehicleType.Common;
            //Act
            var result = _calculateTotalFee.CalculateTotalVehicleFee(vehiclePrice, vehicleType);
            //Asert
            ClassicAssert.AreEqual(173.14,result.Total);
        }

        [Test]
        [TestCase(398.00, VehicleType.Common, 550.76)]
        [TestCase(501.00, VehicleType.Common, 671.02)]
        [TestCase(57.00, VehicleType.Common, 173.14)]
        [TestCase(1800.00, VehicleType.Luxury, 2167.00)]
        [TestCase(1100.00, VehicleType.Common, 1287.00)]
        [TestCase(1000000.00, VehicleType.Luxury, 1040320.00)]
        public void Calculate_TotalVehiclePrice(double vehiclePrice, VehicleType vehicleType, double expectedValue)
        {
            //Act
            var result = _calculateTotalFee.CalculateTotalVehicleFee(vehiclePrice, vehicleType);
            //Asert
            ClassicAssert.AreEqual(expectedValue, result.Total);

        }
    }
}