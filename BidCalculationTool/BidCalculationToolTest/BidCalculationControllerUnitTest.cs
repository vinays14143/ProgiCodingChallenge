using BidCalculationTool.Constants;
using BidCalculationTool.Controllers;
using BidCalculationTool.Enums;
using BidCalculationTool.Interface;
using BidCalculationTool.Models;
using BidCalculationTool.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework.Legacy;
using System.Security.AccessControl;

namespace BidCalculationToolTest
{
    public class BidCalculationControllerUnitTest
    {

        private Mock<ICalculateTotalFee> _calculateTotalFee;
        private Mock<IBidCalculationTool> _bidCalculationTool;

        [SetUp]
        public void Setup()
        {
            _bidCalculationTool = new Mock<IBidCalculationTool>();
            _calculateTotalFee = new Mock<ICalculateTotalFee>();

        }

        [Test]
        [TestCase(398.00, VehicleType.Common)]
        public void Calculate_TotalVehiclePrice_ForValidRequest(double vehiclePrice, VehicleType vehicleType)
        {

            
            _calculateTotalFee.Setup(x => x.CalculateTotalVehicleFee(vehiclePrice, vehicleType)).Returns(It.IsAny<Vehicle>());
            //Act
            var controller = new BidCalculationToolController(_calculateTotalFee.Object);
            var result = controller.Get(vehiclePrice, vehicleType) as OkObjectResult;

            _calculateTotalFee.Verify(x => x.CalculateTotalVehicleFee(vehiclePrice,vehicleType),Times.Once());
            ClassicAssert.IsNotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public void Calculate_TotalVehiclePrice_ForValidRequest()
        {


            _calculateTotalFee.Setup(x => x.CalculateTotalVehicleFee(It.IsAny<double>(), It.IsAny<VehicleType>())).Returns(It.IsAny<Vehicle>());
            //Act
            var controller = new BidCalculationToolController(_calculateTotalFee.Object);
            var result = controller.Get(-1, 0) as BadRequestObjectResult;

            _calculateTotalFee.Verify(x => x.CalculateTotalVehicleFee(It.IsAny<double>(), It.IsAny<VehicleType>()), Times.Never());
            ClassicAssert.IsNotNull(result);
            ClassicAssert.AreEqual(400, result.StatusCode);
        }
    }
}