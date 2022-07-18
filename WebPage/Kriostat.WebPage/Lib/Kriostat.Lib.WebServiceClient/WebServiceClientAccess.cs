namespace Kriostat.Lib.WebServiceClient
{
    public class WebServiceClientAccess
    {
        swaggerClient webService;
        string baseUrl = "http://localhost:7818";
        public WebServiceClientAccess()
        {
            webService = new swaggerClient(baseUrl, new HttpClient() { BaseAddress = new Uri(baseUrl)});
        }

        public async Task<MaterialTypeListResponse> MaterialTypeGetListAsync(string name)
        {
            var response = await webService.MaterialTypeGetListAsync(new MaterialTypeListRequest() { FilterByName = name });

            return response;
        }

        public async Task<MaterialTypeEditResponse> MaterialTypeEditAsync(int id, MaterialTypeDto materialTypeDto)
        {
            var response = await webService.MaterialTypeEditAsync(new MaterialTypeEditRequest() {  FilterById = id, ItemToEdit = materialTypeDto });

            return response;
        }

        public async Task<MaterialTypeDeleteResponse> MaterialTypeDeleteAsync(int id)
        {
            var response = await webService.MaterialTypeDeleteAsync(new MaterialTypeDeleteRequest() { FilterById = id });

            return response;
        }

        public async Task<MaterialTypeAddResponseAdd> MaterialTypeAddAsync(MaterialTypeDto itemToAdd)
        {
            var response = await webService.MaterialTypeAddAsync(new MaterialTypeAddRequestAdd() { MaterialType = itemToAdd });

            return response;
        }
    }
}