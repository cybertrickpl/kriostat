using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wsl.Common.WebService.MaterialType.GetList;
using WSL.DataBase.Repositores;

namespace Wsl.Services.Services
{
    public class MaterialTypeService
    {
        private readonly MaterialTypeRepository _materialTypeRepository;
        public MaterialTypeService(MaterialTypeRepository materialTypeRepository)
        {
            _materialTypeRepository = materialTypeRepository;
        }

        public MaterialTypeGetListResponse GetList(MaterialTypeGetListRequest request)
        {
            MaterialTypeGetListResponse response = new MaterialTypeGetListResponse();
            response.MaterialTypes = _materialTypeRepository.GetList(request.FilterByName);

            return response;
        }
    }
}
