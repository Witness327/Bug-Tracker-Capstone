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
using Microsoft.AspNetCore.Authorization;

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

        public IActionResult UserSingleBug(int id)
        {
            if (id == 0)
            {
                //ToDO - Add logic to handle if no bug exists.
                return Redirect("/");
            }
            var aBug = context.Bugs.Single(b => b.ID == id);
            return View(aBug);
        }

        public IActionResult UserBugs()
        {
            if (HttpContext.Session.GetString("emailaddress")==null)
            {
                return Redirect("Login");
            }

            User user = context.Users.Single(u => u.EmailAddress == HttpContext.Session.GetString("EmailAddress"));
            List<Bug> bugs = context.Bugs.Where(b => b.UserID == user.UserID).ToList();
            return View(bugs);
        }

        public IActionResult AllBugs()
        {


            //User user = context.Users.Single(u => u.EmailAddress == HttpContext.Session.GetString("EmailAddress"));
            List<Bug> allbugs = context.Bugs.ToList();
            return View(allbugs);
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
                try {
                    var aBug = context.Bugs.Single(b => b.ID == id);
                    return Redirect("/Bug/UserSingleBug?id=" + aBug.ID);
                }
                catch
                {
                    
                    return Redirect("/Error");
                }
               
            }
        }

        public IActionResult UpdateStatus(string status, int id)
        {

            var aBug = context.Bugs.Single(b => b.ID == id);
            aBug.Status = status;
            context.Bugs.Update(aBug);
            context.SaveChanges();

            return Redirect("Index");
        }

        public ICollection<Comment> Comments;

        public ICollection<Comment> LocateComments(int id)
        {

            // new IList<Comment> CommList;
            //TODO addthe feature to filter by user ID
            var aComment = context.Comments.OrderByDescending(c => c.Bug.ID == id);
            foreach (var comm in aComment)
            {
                Comments.Add(comm);
            }

            return Comments;
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
                    AdminID = 1,
                };
                context.Bugs.Add(newBug);
                context.SaveChanges();

                return Redirect("/Bug/UserSingleBug?id=" + newBug.ID);
            }

            return View();
        }

    }
}