using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wsl.Common.Dto;
using WSL.DataBase.Tables;

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

        public int Add(MaterialTypeDto ItemToAdd)
        {
            MaterialType materialType = new MaterialType() { Name = ItemToAdd.Name, Description = ItemToAdd.Description };
            _context.MaterialTypes.Add(materialType);
            _context.SaveChanges();

            return materialType.Id;
        }

        public int Delete(int Id)
        {
            var materialType = _context.MaterialTypes.FirstOrDefault(p => p.Id == Id);
                        
            _context.MaterialTypes.Remove(materialType);
            _context.SaveChanges();

            return Id;
        }


        public int Edit(int Id, MaterialTypeDto EditParams)
        {
            
            var materialType = _context.MaterialTypes.FirstOrDefault(p => p.Id == Id);

            materialType.Name = EditParams.Name;
            materialType.Description = EditParams.Description;           
            _context.SaveChanges();

            return Id;
        }

    }
}
