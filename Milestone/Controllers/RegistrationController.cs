using Microsoft.AspNetCore.Mvc;
using Milestone.Models;

namespace Milestone.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegistrationResult(RegistrationModel user)
        {
            return View(user);
        }
    }
}
