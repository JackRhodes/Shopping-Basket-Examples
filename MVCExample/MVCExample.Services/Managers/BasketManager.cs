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
        private readonly IProductManager productManager;

        public BasketManager(IBasketRepository basketRepository, IProductManager productManager)
        {
            this.basketRepository = basketRepository;
            this.productManager = productManager;
        }

        public async Task<int> AddProductToBasketAsync(int productId, Basket basket)
        {
            if (basket == null)
                throw new ArgumentException();

            Product product = await productManager.GetProductByIdAsync(productId);

            if (product == null)
                throw new Exception("Could not retrieve product");

            return await basketRepository.AddProductToBasketAsync(product, basket);
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
