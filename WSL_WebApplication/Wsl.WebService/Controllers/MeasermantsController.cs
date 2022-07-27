using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wsl.Common.WebService.MaterialType.Add;
using Wsl.Common.WebService.MaterialType.Delete;
using Wsl.Common.WebService.MaterialType.Edit;
using Wsl.Common.WebService.MaterialType.GetList;
using Wsl.Services.Services;

namespace Wsl.WebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeasermantsController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly MaterialTypeService _materialTypeService;

        public MeasermantsController(ILogger<WeatherForecastController> logger, MaterialTypeService materialTypeService)
        {
            _logger = logger;
            _materialTypeService = materialTypeService;
        }

        [HttpPost("/MaterialType/UploadValues", Name = "UploadValues")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public UploadValuesResponse UploadValues([FromBody] UploadValuesRequest request)
        {
            MaterialTypeListResponse response = new MaterialTypeListResponse();
            try
            {
                //Tu zrobić przez serwis tak jak w Material TYpe

                byte[] fileContentByte = System.Convert.FromBase64String(request.FileContentBase64);
                string fileContentStr = System.Text.Encoding.UTF8.GetString(fileContentByte);

                string[] lines = fileContentStr.Split(System.Environment.NewLine);

                List<string> data = new List<string>();

                for (int x = 2; x < lines.Count(); x++)
                {
                    data.Add( lines[x]);
                }

                foreach(var row in data)
                {
                    string[] cols = row.Split(' ');
                    if(cols.Length> 1)
                    {

                    }

                }

            }
            catch (Exception ex)
            {

            }

            return new UploadValuesResponse();
        }

    }
}
