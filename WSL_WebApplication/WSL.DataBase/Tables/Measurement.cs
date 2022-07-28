using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSL.DataBase.Tables
{
    [Table("item")]
    public class Measurement
    {
        [Key]
        public int Id { get; set; }
        public int? Temp { get; set; }

        public double? Frequency { get; set; }

        public double? Impedance { get; set; }

        public double? Phase { get; set; }
                
    }
}
