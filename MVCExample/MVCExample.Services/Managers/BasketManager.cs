using Microsoft.AspNetCore.Identity;
using MVCExample.DataAccess.Contracts;
using MVCExample.Models.Data;
using MVCExample.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MVCExample.Services.Managers
{
    public class BasketManager : IBasketManager
    {
        private readonly IBasketRepository basketRepository;

        public BasketManager(IBasketRepository basketRepository)
        {
            this.basketRepository = basketRepository;
        }

        public async Task<IEnumerable<BasketItem>> GetBasketItemsFromBasketAsync(Basket basket)
        {
            if (basket != null)
                return await basketRepository.GetBasketItemsFromBasketAsync(basket);
            else throw new ArgumentException();
        }

        public async Task<Basket> GetUserBasketAsync(IdentityUser identityUser)
        {
            if (identityUser != null)
                return await basketRepository.GetUserBasketAsync(identityUser);
            else throw new ArgumentException();
        }
    }
}
