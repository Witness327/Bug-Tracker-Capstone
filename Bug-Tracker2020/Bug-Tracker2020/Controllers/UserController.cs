using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bug_Tracker2020.Models;
using Bug_Tracker2020.Data;
using Bug_Tracker2020.ViewModels;

namespace Bug_Tracker2020.Controllers
{
    public class UserController : Controller
    {
        private BugDbContext context;

        public UserController(BugDbContext dbContext)
        {
            context = dbContext;
        }


        public IActionResult Add()
        {
            AddUserViewModel addUserViewModel = new AddUserViewModel();
            return View(addUserViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddUserViewModel addUserViewModel)
        {
            if (ModelState.IsValid)
            {

                User newUser = new User
                {
                    EmailAddress = addUserViewModel.EmailAddress,
                    Password = addUserViewModel.Password,
                    Admin = addUserViewModel.Admin,
                };

                context.Users.Add(newUser);
                context.SaveChanges();

                return Redirect("/");
            }

            return View();
        }

    }
}
