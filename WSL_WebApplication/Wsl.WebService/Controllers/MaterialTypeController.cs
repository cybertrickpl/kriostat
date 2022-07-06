using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wsl.Common.WebService.MaterialType.GetList;
using Wsl.Services.Services;

namespace Wsl.WebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MaterialTypeController : ControllerBase
    {
                private readonly ILogger<WeatherForecastController> _logger;
        private readonly MaterialTypeService _materialTypeService;

        public MaterialTypeController(ILogger<WeatherForecastController> logger, MaterialTypeService materialTypeService)
        {
            _logger = logger;
            _materialTypeService = materialTypeService;
        }

        [HttpPost("/MaterialType/GetList", Name = "MaterialTypeGetList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public MaterialTypeGetListResponse MaterialTypeGetList([FromBody] MaterialTypeGetListRequest request)
        {
            MaterialTypeGetListResponse response = new MaterialTypeGetListResponse();
            try
            {
                response = _materialTypeService.GetList(request);
            }
            catch (Exception ex)
            {
              
            }

            return response;
        }
    }
}
