using System;
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
        private readonly IMapper mapper;

        public BasketController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IAccountManager accountManager,
            IBasketManager basketManager,
            IMapper mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.accountManager = accountManager;
            this.basketManager = basketManager;
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

            Parallel.ForEach(basketItemDtos.ToList(),
                i =>
                {
                    productDtos.Add(i.Product);
                }

                );

            BasketViewModel basketViewModel = new BasketViewModel()
            {
                BasketItems = productDtos
            };


            //   BasketDto basketDto

            return View(basketViewModel);
        }

        // GET: Basket/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: Basket/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: Basket/Delete/5
        public ActionResult Remove(int id)
        {
            return View();
        }

        // POST: Basket/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}