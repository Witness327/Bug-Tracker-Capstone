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
using Bug_Tracker2020.ViewModels;

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

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

        //[Route("Login")]
        public IActionResult Login()
        {
            return View();
        }


        
        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                //Logic if Person is an admin
                if (loginViewModel.EmailAddress.Contains("bugtracker.com")){
                    var obj = context.Admins.Where(a => a.EmailAddress.Equals(loginViewModel.EmailAddress) && a.Password.Equals(loginViewModel.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        HttpContext.Session.SetString("emailaddress", obj.EmailAddress);
                        HttpContext.Session.SetInt32("id", obj.AdminID);
                        HttpContext.Session.SetString("firstname", obj.FirstName);
                        HttpContext.Session.SetString("AdminRole", obj.AdminRole.ToString());
                        return View("Welcome");
                    }

                }
                //Logic for all non-Admins
                else {
                    var obj = context.Users.Where(a => a.EmailAddress.Equals(loginViewModel.EmailAddress) && a.Password.Equals(loginViewModel.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        HttpContext.Session.SetString("emailaddress", obj.EmailAddress);
                        HttpContext.Session.SetInt32("id", obj.UserID);
                        HttpContext.Session.SetString("firstname", obj.FirstName);

                        return View("Welcome");
                    }
                }

            }
            //TODO: We need to create a message for incorrect password
            return View("Login");
        }

        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("emailaddress");
            HttpContext.Session.Remove("FirstName");
 
            return RedirectToAction("Index");
        }
    }
}

