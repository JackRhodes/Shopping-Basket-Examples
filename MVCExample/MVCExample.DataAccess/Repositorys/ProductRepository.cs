using MVCExample.Data;
using MVCExample.DataAccess.Contracts;
using MVCExample.Models.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MVCExample.DataAccess.Repositorys
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext context;

        public ProductRepository(ApplicationDbContext context)
        {
            this.context = context;
            //Change tracking breaks when passing using Repository pattern. Disabled as I am not utilising.
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public IEnumerable<Product> FuzzySearchProductByName(string name)
        {
            if (!String.IsNullOrEmpty(name))
                return context.Products.Where(x => x.Name.Contains(name));
            else
                throw new ArgumentException("Null Arguement");
        }

        public async Task<Product> GetProductByIdAsync(int? id)
        {
            return await context.Products.SingleOrDefaultAsync(x => x.ProductId == id);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await context.Products.ToListAsync();
        }

        public async Task<int> CreateProductAsync(Product product)
        {
            context.Products.Add(product);

            return await context.SaveChangesAsync();
        }

        public async Task<int> UpdateProductAsync(Product product)
        {
            context.Products.Update(product);
            //Allow for EF core to know that Entity has been updated. Without this, changing an item twice in a row causes an Exception
            context.Entry(product).State = EntityState.Modified;
            return await context.SaveChangesAsync();
        }

        public async Task<int> DeleteProductByIdAsync(int? id)
        {
            Product product = context.Products.Where(x => x.ProductId == id).SingleOrDefault();
            if (product != null)
            {
                context.Products.Remove(product);
                return await context.SaveChangesAsync();
            }
            else throw new Exception("Product was not found");
        }
    }
}
