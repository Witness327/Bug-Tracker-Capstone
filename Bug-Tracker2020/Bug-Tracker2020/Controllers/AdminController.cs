using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bug_Tracker2020.Data;
using Microsoft.AspNetCore.Mvc;

namespace Bug_Tracker2020.Controllers
{
    public class AdminController : Controller
    {
        private BugDbContext context;

        public AdminController(BugDbContext dbContext)
        {
            context = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}