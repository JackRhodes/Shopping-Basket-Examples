﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCExample.Models.Data;
using MVCExample.Models.DTO;
using MVCExample.Models.ViewModel;
using MVCExample.Services.Contracts;

namespace MVCExample.Controllers
{
    public class BasketController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IAccountManager accountManager;
        private readonly IBasketManager basketManager;
        private readonly IProductManager productManager;
        private readonly IMapper mapper;

        public BasketController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IAccountManager accountManager,
            IBasketManager basketManager,
            IProductManager productManager,
            IMapper mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.accountManager = accountManager;
            this.basketManager = basketManager;
            this.productManager = productManager;
            this.mapper = mapper;
        }

        [Authorize]
        // GET: Basket
        public async Task<ActionResult> Index()
        {
            string userId = userManager.GetUserId(User);
            IdentityUser identityUser = await accountManager.GetCurrentUserAsync(userId);
            Basket basket = await basketManager.GetUserBasketAsync(identityUser);
            IEnumerable<BasketItem> basketItems = await basketManager.GetBasketItemsFromBasketAsync(basket);

            IEnumerable<BasketItemDto> basketItemDtos = mapper.Map<IEnumerable<BasketItemDto>>(basketItems);

            List<ProductDto> productDtos = new List<ProductDto>();

            foreach (var item in basketItemDtos)
            {
                Product product = await productManager.GetProductByIdAsync(item.ProductId);
                ProductDto productDto = mapper.Map<ProductDto>(product);

                productDtos.Add(productDto);

            }
            BasketViewModel basketViewModel = new BasketViewModel()
            {
                BasketItems = productDtos
            };


            //   BasketDto basketDto

            return View(basketViewModel);
        }


        // POST: Basket/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(int productId)
        {
            string userId = userManager.GetUserId(User);
            IdentityUser identityUser = await accountManager.GetCurrentUserAsync(userId);
            Basket basket = await basketManager.GetUserBasketAsync(identityUser);

            await basketManager.AddProductToBasketAsync(productId, basket);

            return RedirectToAction(nameof(Index));
        }

        // POST: Basket/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(int id)
        {

            string userId = userManager.GetUserId(User);
            IdentityUser identityUser = accountManager.GetCurrentUserAsync(userId).Result;
            Basket basket = basketManager.GetUserBasketAsync(identityUser).Result;


            basketManager.RemoveProductFromBasketAsync(id, identityUser);

            return RedirectToAction(nameof(Index));
        }
    }
}