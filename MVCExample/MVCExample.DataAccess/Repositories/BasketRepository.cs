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

namespace MVCExample.DataAccess.Repositories
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

        public Task<BasketItem> GetBasketItemFromBasketByIdAsync(Basket basket, int productId)
        {
           return context.BasketItems.Where(x => x.BasketId == basket.BasketId 
           && x.ProductId == productId)
           .SingleOrDefaultAsync();
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

        public Task<int> RemoveProductFromBasketAsync(BasketItem basketItem)
        {
            context.Entry(basketItem).State = EntityState.Deleted;
            context.BasketItems.Remove(basketItem);
            
            return context.SaveChangesAsync();
        }
    }
}
