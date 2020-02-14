using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Bug_Tracker2020.Data;
using Bug_Tracker2020.Models;
using Bug_Tracker2020.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bug_Tracker2020.Controllers
{
    public class LoginController : Controller
    {
        public BugDbContext context;
        public LoginController(BugDbContext dbContext)
        {
            context = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        //Returns Login view
        public IActionResult Add()
        {
            return View();
        }





        //[HttpPost]
        //public IActionResult Add(NewLoginViewModel newLoginViewModel)
        //{
        //    Login newLogin = new Login
        //    {

        //        EmailAddress = newLoginViewModel.EmailAddress,
        //        Password = newLoginViewModel.Password

        //    };
        //    context.Logins.Add(newLogin);
        //    context.SaveChanges();

        //    return View(newLoginViewModel);
        //}



    }

}