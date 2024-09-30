using MacFood.Context;
using MacFood.Models;
using MacFood.Repositories.Interfaces;

namespace MacFood.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly PurchaseCart _purchaseCart;

        public OrderRepository(AppDbContext appDbContext, PurchaseCart purchaseCart)
        {
            _appDbContext = appDbContext;
            _purchaseCart = purchaseCart;
        }

        public void CreateOrder(Order order)
        {
            order.DeliveredOrderIn = DateTime.Now;
            _appDbContext.Orders.Add(order);
            _appDbContext.SaveChanges();

            var purchaseCartItens = _purchaseCart.GetPurchaseCartItens();

            foreach (var purchaseCart in purchaseCartItens)
            {
                var orderDetail = new OrderDetails
                {
                    Quantity = purchaseCart.Quantity,
                    FoodId = purchaseCart.Food.FoodId,
                    OrderId = order.OrderId,
                    Price = purchaseCart.Food.Value
                };
                _appDbContext.OrderDetails.Add(orderDetail);
            }
            _appDbContext.SaveChanges();
        }
    }
}
