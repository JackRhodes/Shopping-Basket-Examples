using Microsoft.AspNetCore.Identity;
using MVCExample.Models.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MVCExample.DataAccess.Contracts
{
    public interface IBasketRepository
    {
        Task<Basket> GetUserBasketAsync(IdentityUser identityUser);

        Task<IEnumerable<BasketItem>> GetBasketItemsFromBasketAsync(Basket basket);

        Task<int> AddProductToBasketAsync(Product product, Basket basket);

        Task<int> RemoveProductFromBasketAsync(BasketItem basketItem);

        Task<BasketItem> GetBasketItemFromBasketByIdAsync(Basket basket, int productId);
    }
}
