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
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IActionResult> Edit(int? id)
        {
            //Check if user logged in:
            if (HttpContext.Session.GetString("AdminRole") == null)
            {
                return Redirect("/Home/Login");
            }
            if (id == null)
            {
                return NotFound();
            }
            Bug bugToEdit = await context.Bugs.SingleOrDefaultAsync(b => b.ID == id);
            if (bugToEdit == null)
            {
                return NotFound();
            }
            EditBugViewModel editBugViewModel = new EditBugViewModel

            {
                // Select list
                Admins = context.Admins.Select(a => new SelectListItem() { Value = a.AdminID.ToString(), Text = a.FirstName }).ToList(),

                // Set known fields
                ID = bugToEdit.ID,
                CreatedDate = bugToEdit.CreatedDate,
                UserID = bugToEdit.UserID,
                Subject = bugToEdit.Subject,
                Description = bugToEdit.Description,
                Status = bugToEdit.Status,
                AdminID = bugToEdit.AdminID,
                //AdminFirstName = LocateAdminFirstName(bugToEdit.AdminID, bugToEdit.ID).ToString(),

            };
            context.Update(bugToEdit);
            context.SaveChanges();

            //LocateAdminFirstName(bugToEdit.AdminID, bugToEdit.ID).ToString();

            context.Update(bugToEdit);
            context.SaveChanges();


            //};
            return View(editBugViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditBugViewModel editBugViewModel)
        {
            if (ModelState.IsValid)
            {
                //Find bug
                Bug bugToEdit = await context.Bugs.SingleAsync(f => f.ID == editBugViewModel.ID);

                //Set changes
                bugToEdit.AdminID = editBugViewModel.AdminID;
                bugToEdit.AdminFirstName = LocateAdminFirstName(editBugViewModel.AdminID, editBugViewModel.ID).ToString();
                context.Bugs.Update(bugToEdit);
                await context.SaveChangesAsync();
                return Redirect("/Bug/UserSingleBug?id=" + bugToEdit.ID);
            }
            return View(editBugViewModel);
        }

        public IActionResult SingleBug(int id)
        {
            if (HttpContext.Session.GetString("emailaddress") == null)
            {
                return Redirect("Home/Login");
            }
            try
            {

                if (HttpContext.Session.GetString("emailaddress").Contains("@bugtracker.com"))
                {
                    if (id == 0)
                    {
                        //ToDO - Add logic to handle if no bug exists.
                        return Redirect("/");
                    }
                    var aBug = context.Bugs.Single(b => b.ID == id);
                    return View(aBug);
                }
                else
                {
                    return Redirect("UserSingleBug?id=" + id);
                }

            }
            catch
            {
                return Redirect("/Home/Login");
            }


        }

        public IActionResult UserSingleBug(int id)
        {
            if (HttpContext.Session.GetString("emailaddress") == null)
            {
                return Redirect("/Home/Login");
            }
            if (id == 0)
            {
                //ToDO - Add logic to handle if no bug exists.
                return Redirect("/");
            }
            var aBug = context.Bugs.Single(b => b.ID == id);
            aBug.Comments = BugComments(id);
            context.Update(aBug);
            context.SaveChanges();
            return View(aBug);
        }

        public IActionResult UserBugs()
        {
            if (HttpContext.Session.GetString("emailaddress") == null)
            {
                return Redirect("Home/Login");
            }
           

            User user = context.Users.Single(u => u.EmailAddress == HttpContext.Session.GetString("emailaddress"));
            

            List<Bug> bugs = context.Bugs.Where(b => b.UserID == user.UserID).ToList();
            return View(bugs);
        }

        public IActionResult AdminBugs()
        {
            if (HttpContext.Session.GetString("emailaddress") == null)
            {
                return Redirect("Home/Login");
            }


            Admin admin = context.Admins.Single(u => u.EmailAddress == HttpContext.Session.GetString("emailaddress"));


            List<Bug> bugs = context.Bugs.Where(b => b.AdminID == admin.AdminID).ToList();
            return View(bugs);
        }

        public IActionResult AllBugs()
        {
            if (HttpContext.Session.GetString("emailaddress") == null)
            {
                return Redirect("Home/Login");
            }


            //User user = context.Users.Single(u => u.EmailAddress == HttpContext.Session.GetString("EmailAddress"));
            List<Bug> allbugs = context.Bugs.ToList();
            return View(allbugs);
        }

        public List<Comment> BugComments(int id)
        {
            //if (HttpContext.Session.GetString("emailaddress") == null)
            //{
            //    return Redirect("Home/Login");
            //}
            Bug bug = context.Bugs.Single(u => u.ID == id);
            List<Comment> comments = context.Comments.Where(b => b.BugID == bug.ID).ToList();

            bug.Comments = comments;
            context.Update(bug);
            context.SaveChanges();

            return comments;
        }

        public IActionResult UpdateCommentList()
        {

            return View();
        }
        public IActionResult BugSearch()
        {
            return View();

        }
        [HttpPost]
        public IActionResult BugSearch(int id)
        {
            if (HttpContext.Session.GetString("emailaddress") == null)
            {
                return Redirect("Home/Login");
            }
            if (id == 0)
            {
                return Redirect("/");
            }
            else
            {
                try
                {
                    var aBug = context.Bugs.Single(b => b.ID == id);
                    return Redirect("/Bug/UserSingleBug?id=" + aBug.ID);
                }
                catch
                {

                    return Redirect("/Index");
                }

            }
        }

        [HttpPost]
        public IActionResult UpdateStatus(string status, int id, string lastmodifieddate)
        {
            if (HttpContext.Session.GetString("emailaddress") == null)
            {
                return Redirect("/Home/Login");
            }

            var aBug = context.Bugs.Single(b => b.ID == id);
            aBug.Status = status;
            aBug.LastModifiedDate = lastmodifieddate;
            context.Bugs.Update(aBug);
            context.SaveChanges();

            return Redirect("Index");
        }

        public IActionResult UpdateAdmin(int id, string AdminFirstName)
        {

            if (HttpContext.Session.GetString("emailaddress") == null)
            {
                return Redirect("/Home/Login");
            }
            IList<Admin> Names = context.Admins.Include(c => c.FirstName).ToList();

            //Bug aBug = context.Bugs.Single(b => b.ID == id);
            //aBug.AdminFirstName = AdminFirstName;
            //context.Bugs.Update(aBug);
            //context.SaveChanges();

            return View(Names);
        }

        public User Find(string emailaddress)
        {
            //var obj = context.Users.Where(a => a.EmailAddress.Equals(emailaddress));
            var LoggedInUser = context.Users.Single(a => a.EmailAddress == emailaddress);
            return LoggedInUser;
        }

        //Create a new Bug
        //Status is automatically new and AdminID is automatically 1 until is is reassigned
        public IActionResult Add(AddBugViewModel bugViewModel)
        {
            if (HttpContext.Session.GetString("emailaddress") == null)
            {
                return Redirect("/Home/Login");
            }

            if (ModelState.IsValid)
            {

                Bug newBug = new Bug
                {
                    UserFirstName = bugViewModel.UserFirstName,
                    UserID = bugViewModel.UserID,
                    CreatedDate = bugViewModel.CreatedDate,
                    Subject = bugViewModel.Subject,
                    Description = bugViewModel.Description,
                    Status = "New",
                    AdminID = 1,
                };
                context.Bugs.Add(newBug);
                context.SaveChanges();

                newBug.AdminFirstName = LocateAdminFirstName(newBug.AdminID, newBug.ID).ToString();
                context.SaveChanges();
                return Redirect("/Bug/UserSingleBug?id=" + newBug.ID);
            }

            else
            {
                ModelState.AddModelError("ID", "No Bug Found");
                ModelState.AddModelError("username", "Please log in.");
            }

            return View();
        }

        //Update the AdminFirstName field during the bug creation process
        public string LocateAdminFirstName(int AdminID, int ID)
        {
            Admin this_admin = context.Admins.Single(a => a.AdminID == AdminID);
            string AdminFirstName = this_admin.FirstName;
            Bug this_bug = context.Bugs.Find(ID);
            this_bug.AdminFirstName = AdminFirstName;

            context.Bugs.Update(this_bug);
            context.SaveChanges();

            return this_bug.AdminFirstName;
        }

        //Functionality to add Comments
        public IActionResult AddComment(int id)
        {
            if (HttpContext.Session.GetString("emailaddress") == null)
            {
                return Redirect("/Home/Login");
            }
            Comment this_comment = new Comment();
            this_comment.BugID = id;
            return View(this_comment);
        }

        [HttpPost]
        public IActionResult AddComment(AddCommentViewModel addCommentViewModel)
        {
            if (HttpContext.Session.GetString("emailaddress") == null)
            {
                return Redirect("/Home/Login");
            }
            try
            {
                var aBug = context.Bugs.Single(b => b.ID == addCommentViewModel.BugID);
            }
            catch
            {
                return Redirect("/Home/Login");
            }


            if (ModelState.IsValid)
            {
                Comment newComment = new Comment
                {
                    UserID = addCommentViewModel.UserID,
                    UserFirstName = addCommentViewModel.UserFirstName,
                    AdminID = addCommentViewModel.AdminID,
                    AdminFirstName = addCommentViewModel.AdminFirstName,
                    Date = addCommentViewModel.Date,
                    CommentBody = addCommentViewModel.CommentBody,
                    BugID = addCommentViewModel.BugID,

                };
                context.Comments.Add(newComment);
                //BugComments(addCommentViewModel.BugID);

                context.SaveChanges();

                BugComments(addCommentViewModel.BugID);
                return Redirect("/Bug/SingleBug?id=" + addCommentViewModel.BugID);
                //return Redirect("/Bug/SingleBug?id=" + newBug.ID);
            }
            else
            {
                ModelState.AddModelError("ID", "No Bug Found");
                ModelState.AddModelError("username", "Please log in.");

                var errors = ModelState.Select(x => x.Value.Errors)
                                       .Where(y => y.Count > 0)
                                       .ToList();
            }

            return Redirect("/Home/Login");

        }




        //Functionality to edit Comments
        public IActionResult EditComment(int id)
        {

            Comment this_comment = context.Comments.Single(u => u.ID == id);
            return View(this_comment);
        }

        [HttpPost]
        public IActionResult EditComment(EditCommentViewModel editCommentViewModel)
        {
            if (ModelState.IsValid)
            {
                Comment this_comment = context.Comments.Single(u => u.ID == editCommentViewModel.ID);

                this_comment.CommentBody = editCommentViewModel.CommentBody;
                context.Comments.Update(this_comment);
                context.SaveChanges();
            }
            return Redirect("BugSearch");
        }
    


    }
}