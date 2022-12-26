using Microsoft.AspNetCore.Mvc;

namespace FicheDUE.Controllers
{
    [Controller]
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Login Page";
            return View();
        }

        [HttpPost]
        public IActionResult Login()
        {
            var username = Request.Form["username"].ToString();
            var passwd = Request.Form["passwd"].ToString();

            if (username == "admin" && passwd == "1234")
                return RedirectToAction("Index", "Admin");

            return View("Index");
        }
    }
}
