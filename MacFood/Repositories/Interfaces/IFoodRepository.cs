using MacFood.Models;

namespace MacFood.Repositories.Interfaces
{
    public interface IFoodRepository
    {
        IEnumerable<Food> Foods { get; }
        IEnumerable<Food> FavoriteFood { get;  }
        Food GetFoodById(int foodId);
    }
}
