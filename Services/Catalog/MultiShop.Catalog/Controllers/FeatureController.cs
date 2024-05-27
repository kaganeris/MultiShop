using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Services.FeatureServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService featureService;

        public FeatureController(IFeatureService featureService)
        {
            this.featureService = featureService;
        }

        [HttpGet]
        public async Task<IActionResult> FeatureList()
        {
            var values = await featureService.GetAllFeatureAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureById(string id)
        {
            var values = await featureService.GetByIdFeatureAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            await featureService.CreateFeatureAsync(createFeatureDto);
            return Ok("Öne çıkan alan başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFeature(string id)
        {
            await featureService.DeleteFeatureAsync(id);
            return Ok("Öne çıkan alan başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            await featureService.UpdateFeatureAsync(updateFeatureDto);
            return Ok("Öne çıkan alan başarıyla güncellendi");
        }
    }
}
