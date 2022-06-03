using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjektZProgramowania.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZProgramowania.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<User> Users {get; set;}
        public DbSet<ApplicationUser> ApplicationUsers {get; set;}
        public DbSet<Notification> NotificationUsers {get; set;}
        public ApplicationDbContext(DbContextOptions options) : base(options){}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }

    
}
