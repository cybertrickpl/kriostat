using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wsl.Common.Dto;

namespace Wsl.Common.WebService.MaterialType.Edit
{
    public class MaterialTypeEditRequest
    {
        public int FilterById { get; set; }
        public MaterialTypeDto ItemToEdit { get; set; }
    }
}
