using Microsoft.AspNetCore.Mvc;

namespace MacFood.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }

            return RedirectToAction("Login", "Account");
        }
    }
}
