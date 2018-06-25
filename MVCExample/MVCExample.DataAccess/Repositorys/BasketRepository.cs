using MVCExample.Data;
using MVCExample.DataAccess.Contracts;
using MVCExample.Models.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace MVCExample.DataAccess.Repositorys
{
    public class BasketRepository : IBasketRepository
    {
        private readonly ApplicationDbContext context;

        public BasketRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> AddProductToBasketAsync(Product product, Basket basket)
        {
            BasketItem basketItem = new BasketItem()
            {
                BasketId = basket.BasketId,
                ProductId = product.ProductId
            };
            
            context.BasketItems.Add(basketItem);

            return await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<BasketItem>> GetBasketItemsFromBasketAsync(Basket basket)
        {
            return await context.BasketItems
                .Where(x => x.BasketId == basket.BasketId).ToListAsync();
        }

        public Task<Basket> GetUserBasketAsync(IdentityUser identityUser)
        {
            //Include method returns related Entity. 
            return context.Basket
                .Where(x => x.IdentityUserId == identityUser.Id)
                .SingleOrDefaultAsync();     
        }

    }
}
