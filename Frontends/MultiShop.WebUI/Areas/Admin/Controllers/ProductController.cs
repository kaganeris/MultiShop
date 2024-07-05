using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Product")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ProductViewBagList("Ürün İşlemleri");

            var values = await productService.GetAllProductsAsync();

            return View(values);
        }

        [Route("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            ProductViewBagList("Ürün Listesi");

            var values = await productService.GetAllProductsWithCategoryAsync();

            return View(values);
        }

        [Route("CreateProduct")]
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            ProductViewBagList("Ürün Ekleme Sayfası");

            var categoryValues = await categoryService.GetAllCategoriesAsync();

            List<SelectListItem> categoryValues2 = (from c in categoryValues
                                                    select new SelectListItem
                                                    {
                                                        Text = c.CategoryName,
                                                        Value = c.CategoryID
                                                    }).ToList();
            ViewBag.CategoryValues = categoryValues2;

            return View();
        }

        [Route("CreateProduct")]
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await productService.CreateProductAsync(createProductDto);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }

        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await productService.DeleteProductAsync(id);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }

        [Route("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            ProductViewBagList("Ürün Güncelleme Sayfası");

            var values = await productService.GetByIdProductAsync(id);

            var categoryValues = await categoryService.GetAllCategoriesAsync();

            List<SelectListItem> categoryValues2 = (from c in categoryValues
                                                    select new SelectListItem
                                                    {
                                                        Text = c.CategoryName,
                                                        Value = c.CategoryID
                                                    }).ToList();
            ViewBag.CategoryValues = categoryValues2;

            return View(values);
        }

        [Route("UpdateProduct/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await productService.UpdateProductAsync(updateProductDto);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }

        public void ProductViewBagList(string v3)
        {
            ViewBag.v0 = "Ürün İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = v3;
        }
    }
}
