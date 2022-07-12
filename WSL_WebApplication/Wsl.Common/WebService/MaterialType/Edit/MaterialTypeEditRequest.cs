using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Wsl.Common.WebService.MaterialType.Edit
{
    public class MaterialTypeEditRequest
    {
        public int FilterById { get; set; }
        public MaterialType MaterialType { get; set; }
    }
}
