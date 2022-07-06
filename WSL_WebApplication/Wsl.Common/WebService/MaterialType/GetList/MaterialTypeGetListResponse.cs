using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wsl.Common.Dto;

namespace Wsl.Common.WebService.MaterialType.GetList
{
    public class MaterialTypeGetListResponse
    {
        public List<MaterialTypeDto> MaterialTypes { get; set; }
    }
}
