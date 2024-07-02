using MacFood.Models;

namespace MacFood.ViewModels
{
    public class FoodListViewModel
    {
        public IEnumerable<Food> Foods { get; set; }
        public string CurrentCategory { get; set; }
    }
}
