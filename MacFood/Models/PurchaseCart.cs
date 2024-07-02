using MacFood.Context;
using Microsoft.EntityFrameworkCore;

namespace MacFood.Models
{
    public class PurchaseCart
    {
        private readonly AppDbContext _context;

        public PurchaseCart(AppDbContext context)
        {
            _context = context;
        }

        public string PurchaseCartId { get; set; }
        public List<PurchaseCartItem> PurchaseCartItem { get; set; }

        public static PurchaseCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<AppDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new PurchaseCart(context)
            {
                PurchaseCartId = cartId
            };
        }

        public void AddToCart(Food food)
        {
            var purchaseCartItem = _context.PurchaseCartItems.SingleOrDefault(
                    s => s.Food.FoodId == food.FoodId &&
                    s.PurchaseCartId == PurchaseCartId
                );

            if (purchaseCartItem == null)
            {
                purchaseCartItem = new PurchaseCartItem
                {
                    PurchaseCartId = PurchaseCartId,
                    Food = food,
                    Quantity = 1
                };
                _context.PurchaseCartItems.Add(purchaseCartItem);
            }
            else
            {
                purchaseCartItem.Quantity++;
            }
            _context.SaveChanges();
        }

        public int RemoveToCart(Food food)
        {
            var purchaseCartItem = _context.PurchaseCartItems.SingleOrDefault(
                    s => s.Food.FoodId == food.FoodId &&
                    s.PurchaseCartId == PurchaseCartId
                );

            var localQuantity = 0;

            if (purchaseCartItem != null)
            {
                if (purchaseCartItem.Quantity > 1)
                {
                    purchaseCartItem.Quantity--;
                    localQuantity = purchaseCartItem.Quantity;
                }
                else
                {
                    _context.PurchaseCartItems.Remove(purchaseCartItem);
                }
            }

            _context.SaveChanges();
            return localQuantity;
        }

        public List<PurchaseCartItem> GetPurchaseCartItems() 
        {
            return PurchaseCartItem ?? (PurchaseCartItem =
                                        _context.PurchaseCartItems
                                        .Where(c => c.PurchaseCartId == PurchaseCartId)
                                        .Include(s => s.Food)
                                        .ToList());
        }

        public void CleanCart()
        {
            var cartItem = _context.PurchaseCartItems
                .Where(x => x.PurchaseCartId == PurchaseCartId);

            _context.PurchaseCartItems.RemoveRange(cartItem);
            _context.SaveChanges();
        }

        public decimal GetTotalPurchase()
        {
            var totalPurchase = _context.PurchaseCartItems
                                .Where(c => c.PurchaseCartId == PurchaseCartId)
                                .Select(c => c.Food.Value * c.Quantity).Sum();

            return totalPurchase;
        }

    }
}
