using jabr888Q1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jabr888Q1.Data
{
    public class WebAPIDBContext : DbContext
    {
        public WebAPIDBContext(DbContextOptions<WebAPIDBContext> options) : base(options) { }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Marks> Marks { get; set; }
        public DbSet<Enrolments> Enrolments { get; set; }
        public DbSet<Courses> Courses { get; set; }

    }
}
