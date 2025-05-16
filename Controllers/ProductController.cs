using Microsoft.AspNetCore.Mvc;
using TequilaRestaurant.Data;
using TequilaRestaurant.Models;

namespace TequilaRestaurant.Controllers
{
    public class ProductController : Controller
    {
        private Repository<Product> _product;

        public ProductController(ApplicationDbContext context)
        {
            _product = new Repository<Product>(context);
        }
       

        public async Task<IActionResult> Index()
        {
            return View(await _product.GetAllAsync());
        }
    }
}
