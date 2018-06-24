using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCExample.DataAccess.Interfaces;
using MVCExample.Models.Data;

namespace MVCExample.Data
{
    public class ApplicationDbContext : IdentityDbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Basket> Basket { get; set; }
        public DbSet<BasketItem> BasketItems {get;set;}
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductType { get; set; }

    }
}
