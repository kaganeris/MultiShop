using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Catalog.Services.SpecialOfferServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialOfferController : ControllerBase
    {
        private readonly ISpecialOfferService specialOfferService;

        public SpecialOfferController(ISpecialOfferService SpecialOfferService)
        {
            this.specialOfferService = SpecialOfferService;
        }

        [HttpGet]
        public async Task<IActionResult> SpecialOfferList()
        {
            var values = await specialOfferService.GetAllSpecialOffersAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecialOfferById(string id)
        {
            var values = await specialOfferService.GetByIdSpecialOfferAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await specialOfferService.CreateSpecialOfferAsync(createSpecialOfferDto);
            return Ok("Özel teklif başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            await specialOfferService.DeleteSpecialOfferAsync(id);
            return Ok("Özel teklif başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await specialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDto);
            return Ok("Özel teklif başarıyla güncellendi");
        }
    }
}
