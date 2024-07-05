using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;

namespace MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly HttpClient httpClient;

        public SpecialOfferService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await httpClient.PostAsJsonAsync<CreateSpecialOfferDto>("specialoffer", createSpecialOfferDto);
        }

        public async Task DeleteSpecialOfferAsync(string id)
        {
            await httpClient.DeleteAsync($"specialOffer?id={id}");
        }

        public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOffersAsync()
        {
            var responseMessage = await httpClient.GetAsync("specialOffer");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultSpecialOfferDto>>();
            return values;
            
        }

        public async Task<UpdateSpecialOfferDto> GetByIdSpecialOfferAsync(string id)
        {
            var responseMessage = await httpClient.GetAsync($"specialOffer/{id}");
            var value = await responseMessage.Content.ReadFromJsonAsync<UpdateSpecialOfferDto>();
            return value;
        }

        public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            var responseMessage = await httpClient.PutAsJsonAsync<UpdateSpecialOfferDto>("specialOffer", updateSpecialOfferDto);
        }
    }
}
