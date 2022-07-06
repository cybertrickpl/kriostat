using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wsl.Common.Dto;

namespace WSL.DataBase.Repositores
{
    public class MaterialTypeRepository
    {
        private readonly WSLDBContext _context;
        public MaterialTypeRepository(WSLDBContext context)
        {
            _context = context;
        }

        public List<MaterialTypeDto> GetList(string filterName)
        {
            var sql = _context.MaterialTypes.AsQueryable();
            if (!string.IsNullOrEmpty(filterName))
            {
                sql = sql.Where(p => p.Name.Contains(filterName));
            }

            return sql.Select(p => new MaterialTypeDto() { Id = p.Id, Description = p.Description, Name = p.Name }).ToList();
        }
    }
}
