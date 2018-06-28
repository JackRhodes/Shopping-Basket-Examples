using Microsoft.EntityFrameworkCore;
using MVCExample.Data;
using MVCExample.DataAccess.Contracts;
using MVCExample.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCExample.DataAccess.Repositories
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly ApplicationDbContext context;

        public ProductTypeRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<ProductType>> GetAllProductTypesAsync()
        {
            return await context.ProductType.ToListAsync();
        }

        public async Task<ProductType> GetProductTypeByIdAsync(int id)
        {
            return await context.ProductType.SingleOrDefaultAsync(x => x.ProductTypeId == id);
        }
    }
}
