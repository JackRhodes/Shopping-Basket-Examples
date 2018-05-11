using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RazorPageExample.DataAccess;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace RazorPageExample.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context context;
        public ProductRepository(Context context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await context.Product.ToListAsync();
        }

        public async Task<Product> GetProductsByIdAsync(int? id)
        {
            return await context.Product.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
