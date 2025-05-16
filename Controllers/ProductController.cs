using Microsoft.AspNetCore.Mvc;

namespace TequilaRestaurant.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
