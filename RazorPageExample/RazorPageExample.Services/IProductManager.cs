using RazorPageExample.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RazorPageExample.Services
{
    public interface IProductManager
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductsByIdAsync(int? id);

    }
}
