using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wsl.Common.WebService.MaterialType.Add;
using Wsl.Common.WebService.MaterialType.Delete;
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
        public MaterialTypeListResponse MaterialTypeGetList([FromBody] MaterialTypeListRequest request)
        {
            MaterialTypeListResponse response = new MaterialTypeListResponse();
            try
            {
                response = _materialTypeService.GetList(request);
            }
            catch (Exception ex)
            {
              
            }

            return response;
        }


        [HttpPost("/MaterialType/Add", Name = "MaterialTypeAdd")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public MaterialTypeAddResponseAdd MaterialTypeAdd([FromBody] MaterialTypeAddRequestAdd request)
        {
            MaterialTypeAddResponseAdd response = new MaterialTypeAddResponseAdd();
            try
            {
                response = _materialTypeService.Add(request);
            }
            catch (Exception ex)
            {

            }

            return response;
        }

        [HttpPost("/MaterialType/Delete", Name = "MaterialTypeDelete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public MaterialTypeDeleteResponse MaterialTypeDelete([FromBody] MaterialTypeDeleteRequest request)
        {
            MaterialTypeDeleteResponse response = new MaterialTypeDeleteResponse();
            try
            {
                response = _materialTypeService.Delete(request);
            }
            catch (Exception ex)
            {

            }

            return response;
        }

    }
}
