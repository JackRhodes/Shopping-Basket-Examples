using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RazorPageExample.DataAccess
{
   public class Context: IdentityDbContext<User>
    {
        public Context(DbContextOptions<Context> options)
          : base(options)
        {
        }


        //Create database tables
        public DbSet<Basket> Basket { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<ProductType> ProductType { get; set; }

        // public DbSet<Degree_Application.Models.ApplicationUser> AccountModel { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
