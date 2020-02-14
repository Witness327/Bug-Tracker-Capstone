using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bug_Tracker2020.Data;
using Bug_Tracker2020.Models;
using Bug_Tracker2020.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Bug_Tracker2020.Controllers;
using Microsoft.AspNetCore.Http;


namespace Bug_Tracker2020.Controllers
{
    public class BugController : Controller
    {
        private BugDbContext context;

        public BugController(BugDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SingleBug(int id)
        {
            if (id == 0)
            {
                //ToDO - Add logic to handle if no bug exists.
                return Redirect("/");
            }
            var aBug = context.Bugs.Single(b => b.ID == id);
            return View(aBug);
        }

        public IActionResult BugSearch()
        {
            return View();

        }
        [HttpPost]
        public IActionResult BugSearch(int id)
        {
            if (id == 0)
            {
                return Redirect("/");
            }
            else
            {
                var aBug = context.Bugs.Single(b => b.ID == id);
                return Redirect("/Bug/SingleBug?id=" + aBug.ID);
            }
        }

        public User Find(string emailaddress)
        {
            //var obj = context.Users.Where(a => a.EmailAddress.Equals(emailaddress));
            var LoggedInUser = context.Users.Single(a => a.EmailAddress == emailaddress);
            return LoggedInUser;
        }

        public IActionResult Add(AddBugViewModel bugViewModel)
        {
            if (ModelState.IsValid)
            {
                Bug newBug = new Bug
                {
                    UserID = bugViewModel.UserID,
                    //Find the userid using the email address in the session
                    CreatedDate = bugViewModel.CreatedDate,
                    Subject = bugViewModel.Subject,
                    Description = bugViewModel.Description,
                    Status = "New",

                };
                context.Bugs.Add(newBug);
                context.SaveChanges();


                return Redirect("/Bug/SingleBug?id=" + newBug.ID);
            }

            return View();
        }
    }
}