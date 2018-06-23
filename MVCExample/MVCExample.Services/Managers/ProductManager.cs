using MVCExample.DataAccess.Contracts;
using MVCExample.Models.Data;
using MVCExample.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MVCExample.Services.Managers
{
    public class ProductManager : IProductManager
    {
        private readonly IProductRepository productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public Task<IEnumerable<Product>> FuzzySearchProductByName(string name)
        {
            if(!(String.IsNullOrEmpty(name) || String.IsNullOrWhiteSpace(name)))
            {
                return Task.Run(() => productRepository.FuzzySearchProductByName(name));
            }
            else
            {
                throw new ArgumentNullException();
            }
            
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await productRepository.GetAllProductsAsync();
        }

        public async Task<Product> GetProductByIdAsync(int? id)
        {
            return await productRepository.GetProductByIdAsync(id);
        }
    }
}
