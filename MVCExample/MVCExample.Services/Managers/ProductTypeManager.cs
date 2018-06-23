using MVCExample.DataAccess.Contracts;
using MVCExample.Models.Data;
using MVCExample.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MVCExample.Services.Managers
{
    public class ProductTypeManager : IProductTypeManager
    {
        private readonly IProductTypeRepository productTypeRepository;

        public ProductTypeManager(IProductTypeRepository productTypeRepository)
        {
            this.productTypeRepository = productTypeRepository;
        }

        public async Task<IEnumerable<ProductType>> GetAllProductTypesAsync()
        {
            return await productTypeRepository.GetAllProductTypesAsync();
        }

        public async Task<ProductType> GetProductTypeByIdAsync(int id)
        {
            return await productTypeRepository.GetProductTypeByIdAsync(id);
        }
    }
}
