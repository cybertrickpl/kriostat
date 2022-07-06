using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WSL.DataBase.Tables;

namespace WSL.DataBase
{
    public class WSLDBContext : DbContext
    {
        public WSLDBContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<MaterialType> MaterialTypes { get; set; }
    }
}
