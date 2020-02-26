using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bug_Tracker2020.Data;
using Bug_Tracker2020.Models;
using Bug_Tracker2020.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bug_Tracker2020.Controllers
{
    public class CommentController : Controller
    {
        private BugDbContext context;

        public CommentController(BugDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }
        //Locate a Bug and return that Bug
        public Bug Find(int id)
        {
            var aBug = context.Bugs.Single(b => b.ID == id);
            return aBug;
        }



        // GET: Comment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public IActionResult Add()
        {
            AddCommentViewModel addCommentViewModel = new AddCommentViewModel();
            return View(addCommentViewModel);
        }


        //Create a comment
        [HttpPost]
        public IActionResult Add(AddCommentViewModel addCommentViewModel)
        {
            var aBug = context.Bugs.Single(b => b.ID == addCommentViewModel.BugID);

            if (ModelState.IsValid)
            {
                Comment newComment = new Comment
                {
                    UserID = addCommentViewModel.UserID,
                    Date = addCommentViewModel.Date,
                    CommentBody = addCommentViewModel.CommentBody,
                    BugID = addCommentViewModel.BugID,

                };
                context.Comments.Add(newComment);
                context.SaveChanges();

                return Redirect("/Bug/SingleBug?id=" + addCommentViewModel.BugID);
                //return Redirect("/Bug/SingleBug?id=" + newBug.ID);
            }
            else
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                                       .Where(y => y.Count > 0)
                                       .ToList();
            }

            return View();

        }
        //Possible Deletion
        public IActionResult LocateComments(int id)
        {

            // new IList<Comment> CommList;
            //TODO addthe feature to filter by user ID
            var aComment = context.Comments.OrderByDescending(c => c.BugID == id);



            return View(aComment);
        }

        // POST: Comment/Delete/5
        
        
        public IActionResult Delete(int id)
        {
            try
            {
                var delcomment = context.Comments.Find(id);
                //if Logged in Person is an admin
                if (HttpContext.Session.GetString("emailaddress").Contains("@bugtracker.com"))
                {
                    if ((delcomment.AdminFirstName == HttpContext.Session.GetString("firstname")) && (delcomment.AdminID == HttpContext.Session.GetInt32("id"))){
                        context.Comments.Remove(delcomment);
                        context.SaveChanges();
                    }
                }
                //If Logged in Person is not an Admin
                else if (HttpContext.Session.GetString("emailaddress").Contains("@")) {
                    if ((delcomment.UserFirstName == HttpContext.Session.GetString("firstname")) && (delcomment.UserID == HttpContext.Session.GetInt32("id"))){
                        context.Comments.Remove(delcomment);
                        context.SaveChanges();
                    }
                }

                else
                {
                    return Redirect("/Login");
                }
                

                context.Comments.Remove(delcomment);
                context.SaveChanges();

                //TODO where to go
                return Redirect ("/");
            }
            catch
            {
                return Redirect("/");
            }
        }
    }
}