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

        public async Task<IEnumerable<BasketItem>> GetBasketItemsFromBasketAsync(Basket basket)
        {
            return await context.BasketItems.Include(x => x.Basket)
                .Include(x=>x.Product) //Include Product
                .Include(x=>x.Product.ProductType) //Include Product Type
                .Where(x => x.Basket.BasketId == basket.BasketId).ToListAsync();
        }

        public async Task<Basket> GetUserBasketAsync(IdentityUser identityUser)
        {
            //Include method returns related Entity. 
            var task = Task.Run(() => context.Basket.Include(x => x.IdentityUser).Where(x => x.IdentityUser.Id == identityUser.Id).SingleOrDefault());
            return await task;
        }
    }
}
