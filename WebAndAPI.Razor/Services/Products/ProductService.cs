using WebAndAPI.Razor.Services.Products.ViewModels;

namespace WebAndAPI.Razor.Services.Products
{
    public class ProductService(HttpClient client)
    {
        #region Farklı yol ile data almak

        //public Task<ServiceResult<List<ProductViewModel>>> GetAll()
        //{
        //    return client.GetFromJsonAsync<ServiceResult<List<ProductViewModel>>>("/api/Products")!;


        //    //2. way
        //    //var responseMessage = await client.GetAsync("/api/Products");

        //    //return (await responseMessage.Content.ReadFromJsonAsync<ServiceResult<List<ProductViewModel>>>())!;
        //}

        #endregion

        private const string Path = "/api/Products";

        public async Task<ServiceResult<List<ProductViewModel>>> GetAllAsync()
        {
            var responseMessage = await client.GetAsync($"{Path}");


            return (await responseMessage.Content.ReadFromJsonAsync<ServiceResult<List<ProductViewModel>>>())!;
        }


        public async Task<ServiceResult<ProductViewModel>> GetByIdAsync(int id)
        {
            var responseMessage = await client.GetAsync($"{Path}/{id}");


            return (await responseMessage.Content.ReadFromJsonAsync<ServiceResult<ProductViewModel>>())!;
        }

        public async Task<ServiceResult> CreateOrUpdateAsync(ProductCreateOrUpdateViewModel model)
        {
            HttpResponseMessage result = new();

            if (model.IsUpdate)
            {
                result = await client.PutAsJsonAsync($"{Path}", model);
            }

            if (model.IsCreate)
            {
                result = await client.PostAsJsonAsync($"{Path}", model);
            }

            if (!result.IsSuccessStatusCode)
            {
                return (await result.Content.ReadFromJsonAsync<ServiceResult>())!;
            }

            return ServiceResult.Success();
        }


        public async Task<ServiceResult> CreateAsync(ProductCreateOrUpdateViewModel model)
        {
            var responseMessage = await client.PostAsJsonAsync($"{Path}", model);


            return (await responseMessage.Content.ReadFromJsonAsync<ServiceResult>())!;
        }


        public async Task<ServiceResult> UpdateAsync(ProductCreateOrUpdateViewModel model)
        {
            var responseMessage = await client.PutAsJsonAsync($"{Path}", model);


            return (await responseMessage.Content.ReadFromJsonAsync<ServiceResult>())!;
        }


        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var responseMessage = await client.DeleteAsync($"{Path}/{id}");


            if (!responseMessage.IsSuccessStatusCode)
            {
                return (await responseMessage.Content.ReadFromJsonAsync<ServiceResult>())!;
            }

            return ServiceResult.Success();
        }
    }
}