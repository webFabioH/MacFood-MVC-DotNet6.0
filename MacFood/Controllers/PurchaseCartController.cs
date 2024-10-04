using MacFood.Models;
using MacFood.Repositories;
using MacFood.Repositories.Interfaces;
using MacFood.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MacFood.Controllers
{
    public class PurchaseCartController : Controller
    {
        private readonly IFoodRepository _foodRepository;
        private readonly PurchaseCart _purchaseCart;

        public PurchaseCartController(IFoodRepository foodRepository, PurchaseCart purchaseCart)
        {
            _foodRepository = foodRepository;
            _purchaseCart = purchaseCart;
        }

        public IActionResult Index()
        {
            var itens = _purchaseCart.GetPurchaseCartItens();
            _purchaseCart.PurchaseCartItem = itens;

            var purchaseCartVM = new PurchaseCartViewModel
            {
                PurchaseCart = _purchaseCart,
                PurchaseCartTotal = _purchaseCart.GetTotalPurchase()
            };

            return View(purchaseCartVM);
        }

        [Authorize]
        public RedirectToActionResult AddToPurchaseCart(int foodId)
        {
            var SelectedFood = _foodRepository.Foods.FirstOrDefault(s => s.FoodId == foodId);
            if (SelectedFood != null)
            {
                _purchaseCart.AddToCart(SelectedFood);
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        public RedirectToActionResult RemoveToPurchaseCart(int foodId)
        {
            var SelectedFood = _foodRepository.Foods.FirstOrDefault(s => s.FoodId == foodId);
            if (SelectedFood != null)
            {
                _purchaseCart.RemoveToCart(SelectedFood);
            }
            return RedirectToAction("Index");
        }
    }
}
