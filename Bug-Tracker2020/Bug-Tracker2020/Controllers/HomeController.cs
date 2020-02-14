using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bug_Tracker2020.Models;
using Microsoft.AspNetCore.Session;
using Microsoft.Extensions.Logging;
using Bug_Tracker2020.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Bug_Tracker2020.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        
        private BugDbContext context;

        public HomeController(BugDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            return View();
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

        //[Route("Login")]
        public IActionResult Login()
        {
            return View();
        }


        
        [HttpPost]
        public ActionResult Login(string emailaddress, string password)
        {
            if (ModelState.IsValid)
            {
                var obj = context.Users.Where(a => a.EmailAddress.Equals(emailaddress) && a.Password.Equals(password)).FirstOrDefault();
                if (obj != null)
                {
                    HttpContext.Session.SetString("emailaddress", emailaddress);
                    return View("Welcome");
                }

            }
            return View("/Home/Login");
        }

        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("EmailAddress");
            return RedirectToAction("Index");
        }
    }
}

