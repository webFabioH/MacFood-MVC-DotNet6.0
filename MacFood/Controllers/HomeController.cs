using MacFood.Models;
using MacFood.Repositories.Interfaces;
using MacFood.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MacFood.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFoodRepository _foodRepository;

        public HomeController(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                FavoriteFoods = _foodRepository.FavoriteFood
            };

            return View(homeViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
