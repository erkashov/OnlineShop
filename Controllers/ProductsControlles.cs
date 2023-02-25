using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Controllers
{
    public class ProductsControlles : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
