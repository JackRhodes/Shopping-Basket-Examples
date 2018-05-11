using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RazorPageExample.DataAccess
{
   public class Context: IdentityDbContext<User>
    {
        public Context(DbContextOptions<Context> options)
          : base(options)
        {
        }


        //Create database tables
        public virtual DbSet<Basket> Basket { get; set; }

        public virtual DbSet<Product> Product { get; set; }

        public virtual DbSet<ProductType> ProductType { get; set; }

        public virtual Task<IEnumerable<Product>> Products()
        {
            throw new NotImplementedException();
        }

        // public DbSet<Degree_Application.Models.ApplicationUser> AccountModel { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
