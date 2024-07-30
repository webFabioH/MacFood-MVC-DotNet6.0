using MacFood.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MacFood.Components
{
    public class MenuCategory : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;

        public MenuCategory(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categories= _categoryRepository.Categories.OrderBy(c => c.CategoryName);
            return View(categories);
        }
    }
}
