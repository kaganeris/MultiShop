using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;

namespace MultiShop.WebUI.Services.CatalogServices.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient httpClient;

        public CategoryService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var responseMessage = await httpClient.PostAsJsonAsync<CreateCategoryDto>("category", createCategoryDto);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await httpClient.DeleteAsync($"category?id={id}");
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoriesAsync()
        {
            var responseMessage = await httpClient.GetAsync("category");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultCategoryDto>>();
            return values;
        }

        public async Task<UpdateCategoryDto> GetByIdCategoryAsync(string id)
        {
            var responseMessage = await httpClient.GetAsync($"category/{id}");
            var value = await responseMessage.Content.ReadFromJsonAsync<UpdateCategoryDto>();
            return value;
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var responseMessage = await httpClient.PutAsJsonAsync<UpdateCategoryDto>("category", updateCategoryDto);
        }
    }
}
