using MVCExample.Models.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVCExample.DataAccess.Contracts
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int? id);

        IEnumerable<Product> FuzzySearchProductByName(string name);

        Task<IEnumerable<Product>> GetAllProductsAsync();

        Task<int> CreateProductAsync(Product product);      
    }
}
