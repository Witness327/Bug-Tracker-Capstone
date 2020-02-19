using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bug_Tracker2020.Models;
using Bug_Tracker2020.Data;
using Bug_Tracker2020.ViewModels;
using Microsoft.AspNetCore.Http;

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
                if (context.Admins.Count() == 0)
                {
                    Admin unassignedAdmin = new Admin
                    {

                        FirstName = "Unassigned",
                        EmailAddress = "Unassigned@bugtracker.com",
                        Password = "Unassigned123",
                        AdminRole = true,
                    };
                    context.Admins.Add(unassignedAdmin);
                    context.SaveChanges();
                }
                if (addUserViewModel.EmailAddress.Contains("@bugtracker.com")){

                    Admin newAdmin = new Admin
                    {
                        FirstName = addUserViewModel.FirstName,
                        EmailAddress = addUserViewModel.EmailAddress,
                        Password = addUserViewModel.Password,
                        AdminRole = true,
                    };

                    context.Admins.Add(newAdmin);
                    context.SaveChanges();

                    return Redirect("/");
                }

                else
                {
                    User newUser = new User
                    {
                        FirstName = addUserViewModel.FirstName,
                        EmailAddress = addUserViewModel.EmailAddress,
                        Password = addUserViewModel.Password,
                        AdminRole = false,
                    };

                    context.Users.Add(newUser);
                    context.SaveChanges();

                    return Redirect("/");
                }
            }

            return View();
        }

    }
}
