using System;
using AutoMapper;
using MVCExample.Models.Data;
using MVCExample.Models.DTO;

namespace MVCExample.Models.MappingProfiles
{
    public class DTOMapper : Profile
    {
        public DTOMapper()
        {
            CreateMap<Basket, BasketDto>()
                .ReverseMap();
            
            CreateMap<BasketItem, BasketDto>()
                .ReverseMap();

            CreateMap<Product, ProductDto>()
                .ReverseMap();
            
            CreateMap<ProductType, ProductTypeDto>()
                .ReverseMap();

            //CreateMap<Account, AccountDto>()
            //    .ReverseMap();

        }
        
    }
}
