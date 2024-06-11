using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Services.ProductDetailServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        private readonly IProductDetailService productDetailService;

        public ProductDetailController(IProductDetailService productDetailService)
        {
            this.productDetailService = productDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetailList()
        {
            var values = await productDetailService.GetAllProductDetailsAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailById(string id)
        {
            var values = await productDetailService.GetByIdProductDetailAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            await productDetailService.CreateProductDetailAsync(createProductDetailDto);
            return Ok("Ürün Detayı başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            await productDetailService.DeleteProductDetailAsync(id);
            return Ok("Ürün Detayı başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            await productDetailService.UpdateProductDetailAsync(updateProductDetailDto);
            return Ok("Ürün Detayı başarıyla güncellendi");
        }

        [HttpGet("GetProductDetailByProductId")]
        public async Task<IActionResult> GetProductDetailByProductId(string id)
        {
            var values = await productDetailService.GetByProductIdProductDetailAsync(id);
            return Ok(values);
        }
    }
}
