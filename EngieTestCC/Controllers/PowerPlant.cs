using EngieTestCC.Models;
using EngieTestCC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EngieTestCC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PowerPlant : ControllerBase
    {
        private readonly IPlanGenerator _planGenerator;

        public PowerPlant(IPlanGenerator planGenerator)
        {
            _planGenerator = planGenerator;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        [HttpPost("PlanGenerator")]
        public IActionResult PlanGenerator(RequestModel requestModel)
        {
            // Create the fuel object for Genrate Plan
            List<FuelCost> FuelCost = new List<FuelCost>() {
            new FuelCost {Type= FuelType.Gas, Cost= requestModel.fuels.gas },
            new FuelCost {Type= FuelType.Kerosine, Cost= requestModel.fuels.kerosine },
            new FuelCost {Type= FuelType.Wind, Cost= requestModel.fuels.wind },
            };

            //This method will return the multitude of all given power plants
            var result = _planGenerator.GeneratePlan(requestModel.load, FuelCost, requestModel.powerplants);
            return Ok(result);
        }
    }
}
