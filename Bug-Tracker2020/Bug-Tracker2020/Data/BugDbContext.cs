using Bug_Tracker2020.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bug_Tracker2020.Data
{
    public class BugDbContext : DbContext
    {
        public DbSet<Bug> Bugs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public BugDbContext(DbContextOptions<BugDbContext> options) : base(options)
        {
        }

    }
}
