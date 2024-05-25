using DotnetLearning.Core.FileOperations.Models;
using DotnetLearning.Core.ImageClassification.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DotnetLearning.Api.Controllers.Consumption
{
    [Route("predict")]
    public class ConsumptionController(IImageConsumptionService imageConsumptionService) : ControllerBase
    {
        private readonly IImageConsumptionService _imageConsumptionService = imageConsumptionService;

        [HttpPost]
        public IActionResult Predict([FromBody] ImageTraningModel input)
        {
            var result = _imageConsumptionService.Predict(input);

            return Ok(result);
        }
    }
}
