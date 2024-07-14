using WebAndAPI.Razor.Services.Products.ViewModels;

namespace WebAndAPI.Razor.Services.Products
{
    public class ProductService(HttpClient client)
    {
        //public Task<ServiceResult<List<ProductViewModel>>> GetAll()
        //{
        //    return client.GetFromJsonAsync<ServiceResult<List<ProductViewModel>>>("/api/Products")!;


        //    //2. way
        //    //var responseMessage = await client.GetAsync("/api/Products");

        //    //return (await responseMessage.Content.ReadFromJsonAsync<ServiceResult<List<ProductViewModel>>>())!;
        //}

        public Task<ServiceResult<List<ProductViewModel>>> GetAllAsync() =>
            client.GetFromJsonAsync<ServiceResult<List<ProductViewModel>>>("/api/Products")!;


        public Task<ServiceResult<ProductViewModel>> GetByIdAsync(int id) =>
            client.GetFromJsonAsync<ServiceResult<ProductViewModel>>($"/api/Products/{id}")!;
    }
}