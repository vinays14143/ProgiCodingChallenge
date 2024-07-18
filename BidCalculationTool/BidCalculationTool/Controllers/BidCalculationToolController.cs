using BidCalculationTool.Enums;
using BidCalculationTool.Interface;
using BidCalculationTool.Models;
using BidCalculationTool.Services;
using Microsoft.AspNetCore.Mvc;

namespace BidCalculationTool.Controllers
{
    [ApiController]
    [Route("api/v1/bidcalculation")]
    public class BidCalculationToolController : ControllerBase
    {

        private readonly ICalculateTotalFee _calculateTotalFee;

        public BidCalculationToolController(ICalculateTotalFee calculateTotalFee)
        {
            _calculateTotalFee = calculateTotalFee;
        }

        [Route("totalprice")]
        [HttpGet]
        public ActionResult Get(double vehiclePrice, VehicleType vehicleType)
        {
            if(vehiclePrice < 0 || vehicleType == 0) 
            {
                return BadRequest("Vehicle price and Vehicle type is required");
            }
            var result = _calculateTotalFee.CalculateTotalVehicleFee(vehiclePrice, vehicleType);
            return Ok(new List<Vehicle> { result });
        }
    }
}