using MacFood.Models;
using MacFood.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MacFood.Components
{
    public class PurchaseCartSummary : ViewComponent
    {
        private readonly PurchaseCart _purchaseCart;

        public PurchaseCartSummary(PurchaseCart purchaseCart)
        {
            _purchaseCart = purchaseCart;
        }

        public IViewComponentResult Invoke()
        {
            var itens = _purchaseCart.GetPurchaseCartItens();
            //var itens = new List<PurchaseCartItem>()
            //{
            //    new PurchaseCartItem(),
            //    new PurchaseCartItem()
            //};
            _purchaseCart.PurchaseCartItem = itens;

            var purchaseCartVM = new PurchaseCartViewModel
            {
                PurchaseCart = _purchaseCart,
                PurchaseCartTotal = _purchaseCart.GetTotalPurchase()
            };

            return View(purchaseCartVM);
        }
    }
}
