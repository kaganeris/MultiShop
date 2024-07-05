using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using System.Net.Http.Json;

namespace MultiShop.WebUI.Services.CatalogServices.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly HttpClient httpClient;

        public ProductService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var responseMessage = await httpClient.PostAsJsonAsync<CreateProductDto>("product", createProductDto);
        }

        public async Task DeleteProductAsync(string id)
        {
            await httpClient.DeleteAsync($"product?id={id}");
        }

        public async Task<List<ResultProductDto>> GetAllProductsAsync()
        {

            var responseMessage = await httpClient.GetAsync("product");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductDto>>();
            return values;
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductsWithCategoryAsync()
        {
            var responseMessage = await httpClient.GetAsync("product/ProductListWithCategory");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductWithCategoryDto>>();
            return values;
        }

        public async Task<UpdateProductDto> GetByIdProductAsync(string id)
        {
            var responseMessage = await httpClient.GetAsync($"product/{id}");
            var value = await responseMessage.Content.ReadFromJsonAsync<UpdateProductDto>();
            return value;
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryByCategoryIdAsync(string categoryId)
        {
            var responseMessage = await httpClient.GetAsync($"product/ProductListWithCategoryByCategoryId?id={categoryId}");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductWithCategoryDto>>();
            return values;
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var responseMessage = await httpClient.PutAsJsonAsync<UpdateProductDto>("product", updateProductDto);
        }
    }
}
