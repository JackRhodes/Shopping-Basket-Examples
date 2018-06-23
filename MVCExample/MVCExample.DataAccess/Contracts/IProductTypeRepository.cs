using MVCExample.Models.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MVCExample.DataAccess.Contracts
{
    public interface IProductTypeRepository
    {
        Task<IEnumerable<ProductType>> GetAllProductTypesAsync();

        Task<ProductType> GetProductTypeByIdAsync(int id);
    }
}
