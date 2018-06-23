using MVCExample.Models.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MVCExample.Services.Contracts
{
    public interface IProductTypeManager
    {
        Task<IEnumerable<ProductType>> GetAllProductTypesAsync();

        Task<ProductType> GetProductTypeByIdAsync(int id);
    }
}
