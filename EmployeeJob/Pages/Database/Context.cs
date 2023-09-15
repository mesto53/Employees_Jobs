using EmployeeJob.Pages.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeeJob.Pages.Database
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Employees> Employee { get; set; }
        public DbSet<Jobs> Jobs { get; set; }
        public DbSet<EJ> EmployeeJobs {get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EJ>()
                .HasKey(e => new { e.Eid, e.Jid });
        }
    }
}
