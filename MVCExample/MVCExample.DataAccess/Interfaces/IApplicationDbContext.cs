using Microsoft.EntityFrameworkCore;
using MVCExample.Models.Data;
using System;
using System.Collections.Generic;
using System.Text;


namespace MVCExample.DataAccess.Interfaces
{
    public interface IApplicationDbContext: IDisposable
    {
        DbSet<Basket> Basket { get; set; }
        DbSet<BasketItem> BasketItems { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ProductType> ProductType { get; set; }
    }
}
