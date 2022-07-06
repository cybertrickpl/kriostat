using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSL.DataBase.Tables
{
    [Table("material_type")]
    public class MaterialType
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime? CreateStamp { get; set; }

        public string? ChemicalFormula { get; set; }

    }
}
