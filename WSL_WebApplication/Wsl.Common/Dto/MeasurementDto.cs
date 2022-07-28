using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wsl.Common.Dto
{
    public class MeasurementDto
    {
        public int Id { get; set; }

        public double Frequency { get; set; }

        public double Impedance { get; set; }

        public double Phase { get; set; }

    }
}
