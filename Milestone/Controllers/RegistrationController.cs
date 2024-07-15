using Microsoft.AspNetCore.Mvc;
using Milestone.Models;
using Milestone.Services;
using System.Linq.Expressions;

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
            RegistrationDAO registrationDAO = new RegistrationDAO();

            if (registrationDAO.RegisterUser(user))
            {
                return View("RegistrationResult", user);
            }
            else
            {
                return View("Error", new ErrorViewModel { RequestId = "RegistrationFailed" });
            }
        }     
    }
}
