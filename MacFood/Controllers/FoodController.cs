using MacFood.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MacFood.Controllers
{
    public class FoodController : Controller
    {
        private readonly IFoodRepository _foodRepository;

        public FoodController(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public IActionResult List()
        {
            var foods = _foodRepository.Foods;
            return View(foods);
        }
    }
}
