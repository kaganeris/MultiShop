using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/ProductDetail")]
    public class ProductDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("UpdateProductDetail/{id}")]
        public async Task<IActionResult> UpdateProductDetail(string id)
        {
            ViewBag.v0 = "Ürün İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Açıklama ve Bilgi Güncelleme Sayfası";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7150/api/ProductDetail/GetProductDetailByProductId?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateProductDetailDto>(jsonData);
                ViewBag.productDetailProductId = id;
                return View(value);
            }
            return View();
        }

        [HttpPost]
        [Route("UpdateProductDetail/{id}")]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = new HttpResponseMessage();
            if(dto.ProductDetailID != null)
                responseMessage = await client.PutAsync("https://localhost:7150/api/ProductDetail", stringContent);
            else
                responseMessage = await client.PostAsync("https://localhost:7150/api/ProductDetail", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
            }
            return View(dto);
        }
    }
}
