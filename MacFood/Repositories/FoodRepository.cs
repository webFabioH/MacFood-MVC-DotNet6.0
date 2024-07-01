using MacFood.Context;
using MacFood.Models;
using MacFood.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MacFood.Repositories
{
    public class FoodRepository : IFoodRepository
    {
        private readonly AppDbContext _context;

        public FoodRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Food> Foods => _context.Foods.Include(c => c.Category);

        public IEnumerable<Food> FavoriteFood => _context.Foods.Where(f => f.IsFavoriteFood).Include(c => c.Category);

        public Food GetFoodById(int foodId)
        {
            return _context.Foods.FirstOrDefault(f => f.FoodId == foodId);  
        }
    }
}
