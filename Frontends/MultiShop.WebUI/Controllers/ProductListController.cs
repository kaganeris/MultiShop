using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        public IActionResult Index(string id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpGet]
        public IActionResult ProductDetail(string productId)
        {
            ViewBag.x = productId;
            return View();
        }
    }
}
