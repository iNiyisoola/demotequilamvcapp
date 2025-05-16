using Microsoft.AspNetCore.Mvc;
using TequilaRestaurant.Data;
using TequilaRestaurant.Models;

namespace TequilaRestaurant.Controllers
{
    public class IngredientController : Controller
    {
        private Repository<Ingredient> _ingredients;

        public IngredientController(ApplicationDbContext context)
        {
            _ingredients = new Repository<Ingredient>(context);
        }
        public async Task<IActionResult> Index()
        {
            return View(await _ingredients.GetAllAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _ingredients.GetByIdAsync(id, new QueryOptions<Ingredient>() { Includes = "ProductIngredients.Product" }));
        }

        //Ingredient/create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IngredientId, Name")] Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                await _ingredients.AddAsync(ingredient);
                return RedirectToAction("Index");
            }
            return View(ingredient);
        }

        //Ingredient/delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _ingredients.GetByIdAsync(id, new QueryOptions<Ingredient>() { Includes = "ProductIngredients.Product" }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Ingredient ingredient)
        {
            await _ingredients.DeleteAsync(ingredient.IngredientId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _ingredients.GetByIdAsync(id, new QueryOptions<Ingredient>() { Includes = "ProductIngredients.Product" }));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("IngredientId, Name")] Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                await _ingredients.UpdateAsync(ingredient);
                return RedirectToAction("Index");
            }
            return View(ingredient);
        }
    }
}
