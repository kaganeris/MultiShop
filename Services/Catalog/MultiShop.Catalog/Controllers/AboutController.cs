using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.AboutDtos;
using MultiShop.Catalog.Services.AboutServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService aboutService;

        public AboutController(IAboutService AboutService)
        {
            this.aboutService = AboutService;
        }

        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var values = await aboutService.GetAllAboutsAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAboutById(string id)
        {
            var values = await aboutService.GetByIdAboutAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            await aboutService.CreateAboutAsync(createAboutDto);
            return Ok("Hakkında başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAbout(string id)
        {
            await aboutService.DeleteAboutAsync(id);
            return Ok("Hakkında başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            await aboutService.UpdateAboutAsync(updateAboutDto);
            return Ok("Hakkında başarıyla güncellendi");
        }
    }
}
