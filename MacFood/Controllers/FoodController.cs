using MacFood.Repositories.Interfaces;
using MacFood.Models;
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

        public IActionResult List(string category)
        {
            IEnumerable<Food> foods;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category)) 
            {
                foods = _foodRepository.Foods.OrderBy(f => f.FoodId);
                currentCategory = "All foods";
            }
            else
            {
                //if(string.Equals("FastFood", category, StringComparison.OrdinalIgnoreCase))
                //{
                //    foods = _foodRepository.Foods.Where(f => f.Category.CategoryName.Equals("FastFood"))
                //        .OrderBy(f => f.FoodName);
                //}
                //else
                //{
                //    foods = _foodRepository.Foods.Where(f => f.Category.CategoryName.Equals("FitFood"))
                //        .OrderBy(f => f.FoodName);
                //}

                foods = _foodRepository.Foods
                    .Where(f => f.Category.CategoryName.Equals(category))
                    .OrderBy(f => f.FoodName);

                currentCategory = category;
            }

            var foodListViewModel = new FoodListViewModel
            {
                Foods = foods,
                CurrentCategory = currentCategory
            };

            return View(foodListViewModel);
        }

        public IActionResult Details(int foodId) 
        {
            var food = _foodRepository.Foods.FirstOrDefault(f => f.FoodId == foodId);
            return View(food);
        }

        public ViewResult Search(string searchstring)
        {
            IEnumerable<Food> foods;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(searchstring))
            {
                foods = _foodRepository.Foods.OrderBy(p => p.FoodId);
                currentCategory = "All foods";
            }
            else
            {
                foods = _foodRepository.Foods.Where(p => p.FoodName.ToLower().Contains(searchstring.ToLower()));

                if (foods.Any())
                {
                    currentCategory = "Foods";
                }
                else
                {
                    currentCategory = "No food found";
                }
            }

            return View("~/Views/Food/List.cshtml", new FoodListViewModel
            {
                Foods = foods,
                CurrentCategory = currentCategory
            });
        }
    }
}
