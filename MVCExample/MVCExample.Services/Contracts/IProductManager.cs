using MVCExample.Models.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MVCExample.Services.Contracts
{
    public interface IProductManager
    {
        Task<Product> GetProductByIdAsync(int? id);

        Task<IEnumerable<Product>> FuzzySearchProductByName(string name);
    }
}
