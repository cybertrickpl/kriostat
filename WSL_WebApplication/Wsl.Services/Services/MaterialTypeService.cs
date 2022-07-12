using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wsl.Common.WebService.MaterialType.Add;
using Wsl.Common.WebService.MaterialType.Delete;
using Wsl.Common.WebService.MaterialType.Edit;
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

        public MaterialTypeListResponse GetList(MaterialTypeListRequest request)
        {
            MaterialTypeListResponse response = new MaterialTypeListResponse();
            response.MaterialTypes = _materialTypeRepository.GetList(request.FilterByName);

            return response;
        }

        public MaterialTypeAddResponseAdd Add(MaterialTypeAddRequestAdd request)
        {
            MaterialTypeAddResponseAdd response = new MaterialTypeAddResponseAdd();
            response.Id = _materialTypeRepository.Add(request.MaterialType);

            return response;
        }

        public MaterialTypeDeleteResponse Delete(MaterialTypeDeleteRequest request)
        {
            MaterialTypeDeleteResponse response = new MaterialTypeDeleteResponse();
            response.Id = _materialTypeRepository.Delete(request.FilterById);

            return response;
        }

        public MaterialTypeEditResponse Edit(MaterialTypeEditRequest request)
        {
            MaterialTypeEditResponse response = new MaterialTypeEditResponse();
            response.Id = _materialTypeRepository.Edit(request.FilterById, request.MaterialType);

            return response;
        }
    }
}
