using Microsoft.AspNetCore.Mvc;
using MacFood.Repositories.Interfaces;
using MacFood.Models;

namespace MacFood.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly PurchaseCart _purchaseCart;

        public OrderController(IOrderRepository orderRepository, PurchaseCart purchaseCart)
        {
            _orderRepository = orderRepository;
            _purchaseCart = purchaseCart;
        }

        public  IActionResult Checkpout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            int totalItemsOrder = 0;
            decimal orderTotalPrice = 0.0m;

            List<PurchaseCartItem> items = _purchaseCart.GetPurchaseCartItens();
            _purchaseCart.PurchaseCartItem = items;

            if (_purchaseCart.PurchaseCartItem.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty, how about adding a food...");
            }

            foreach (var item in items)
            {
                totalItemsOrder += item.Quantity;
                orderTotalPrice += (item.Food.Value * item.Quantity);
            }

            order.OrderTotalItens = totalItemsOrder;
            order.TotalOrder = orderTotalPrice;

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);

                ViewBag.CheckoutCompleteMessage = "Thanks for your order!";
                ViewBag.TotalOrder = _purchaseCart.GetTotalPurchase();

                _purchaseCart.CleanCart();

                return View("~/Views/Order/CompleteCheckout.cshtml", order);
            }

            return View(order);
        }
    }
}
