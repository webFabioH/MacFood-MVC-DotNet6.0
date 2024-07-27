using Microsoft.AspNetCore.Mvc;

namespace MacFood.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
