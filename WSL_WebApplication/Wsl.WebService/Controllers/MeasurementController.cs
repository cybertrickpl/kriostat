using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wsl.Common.WebService.Measurement.UploadValues;
using Wsl.Services.Services;

namespace Wsl.WebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeasurementController : ControllerBase
    {
        private readonly ILogger<MeasurementController> _logger;
        private readonly MeasurementService _measurementService;

        public MeasurementController(ILogger<MeasurementController> logger, MeasurementService measurementService)
        {
            _logger = logger;
            _measurementService = measurementService;
        }

        [HttpPost("/Measurement/UploadValues", Name = "UploadValues")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public UploadValuesResponse UploadValues([FromBody] UploadValuesRequest request)
        {
            UploadValuesResponse response = new UploadValuesResponse();
            
            try
            {
                response = _measurementService.UploadValues(request);
            }
            catch (Exception ex)
            {

            }

            return response;
        }

    }
}
