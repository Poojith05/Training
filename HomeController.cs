using EmployeePortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EmployeePortal.Controllers
{
    public class HomeController : Controller
    {
        DetailsDbContext dbcontext;
        public HomeController(DetailsDbContext context)
        {
            dbcontext = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string userName,string password)
        {
            User name = dbcontext.Users.SingleOrDefault(item => item.UserName == userName);
           
            if (name != null)
            {
                if (name.UserPassword == password) 
                {
                    ViewBag.Message = "Welcome";
                    return RedirectToAction("Index","Employee");

                }

                else
                {
                    ViewBag.Message = "Wrong Password";
                    return View("Login");
                }
               
            }
            else
            {
                ViewBag.Message = "Invalid credentials";
                return View("Login");
            }


        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
