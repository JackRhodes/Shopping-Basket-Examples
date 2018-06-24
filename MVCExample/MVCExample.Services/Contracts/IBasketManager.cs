using Microsoft.AspNetCore.Identity;
using MVCExample.Models.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MVCExample.Services.Contracts
{
    public interface IBasketManager
    {
        Task<Basket> GetUserBasketAsync(IdentityUser identityUser);

        Task<IEnumerable<BasketItem>> GetBasketItemsFromBasketAsync(Basket basket);
    }
}
