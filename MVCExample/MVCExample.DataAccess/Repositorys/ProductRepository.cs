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
    }
}
