using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wsl.Common.Dto;

namespace Wsl.Common.WebService.Measurement.UploadValues
{
    public class UploadValuesRequest
    {
        public string FileContentBase64 { get; set; }
    }
}
