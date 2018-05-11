using RazorPageExample.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RazorPageExample.Services
{
    public class ProductManager:IProductManager
    {
        private readonly IProductRepository productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await productRepository.GetProductsAsync();
        }

        public async Task<Product> GetProductsByIdAsync(int? id)
        {
            return await productRepository.GetProductsByIdAsync(id);
        }

    }
}
