using MacFood.Repositories.Interfaces;
using MacFood.ViewModels;
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
            //var foods = _foodRepository.Foods;
            //var totalFoods = foods.Count();
            //return View(foods);
            var foodListViewModel = new FoodListViewModel();
            foodListViewModel.Foods = _foodRepository.Foods;
            foodListViewModel.CurrentCategory = "Current Category";

            return View(foodListViewModel);
        }
    }
}
