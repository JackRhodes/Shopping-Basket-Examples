using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCExample.Models.Data;
using MVCExample.Models.DTO;
using MVCExample.Models.ViewModel;
using MVCExample.Services.Contracts;

namespace MVCExample.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductManager productManager;
        private readonly IMapper mapper;
        private readonly IProductTypeManager productTypeManager;

        public ProductController(IProductManager productManager, IMapper mapper, IProductTypeManager productTypeManager)
        {
            this.productManager = productManager;
            this.mapper = mapper;
            this.productTypeManager = productTypeManager;
        }

        // GET: Product
        public async Task<ActionResult> Index()
        {
            IEnumerable<Product> products = await productManager.GetAllProductsAsync();

            IEnumerable<ProductDto> productDto = Mapper.Map<IEnumerable<ProductDto>>(products);

            ProductsDto productsViewModel = new ProductsDto()
            {
                Products = productDto.ToList()
            };

            return View(productsViewModel);
        }

        // GET: Product/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Product product = await productManager.GetProductByIdAsync(id);
            ProductDto productViewModel = Mapper.Map<ProductDto>(product);

            return View(productViewModel);
        }

        // GET: Product/Create
        public async Task<ActionResult> Create()
        {
            IEnumerable<ProductType> productType = await productTypeManager.GetAllProductTypesAsync();

            IEnumerable<ProductTypeDto> productTypeDto = mapper.Map<IEnumerable<ProductTypeDto>>(productType);

            ProductCreateViewModel productCreateViewModel = new ProductCreateViewModel()
            {
                ProductDto = new ProductDto(),

                ProductTypeDtos = productTypeDto.ToList()
            };

            return View(productCreateViewModel);
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("ProductDto,ProductTypeDtos,ProductType")] ProductCreateViewModel productCreateViewModel)
        {

            if (ModelState.IsValid)
            {
                //Refactor when possible
                ProductType productType = await productTypeManager.GetProductTypeByIdAsync(productCreateViewModel.ProductType);

                ProductDto productDto = productCreateViewModel.ProductDto;

                Product product = Mapper.Map<Product>(productDto);

                product.ProductType = productType;

                await productManager.CreateProductAsync(product);

                return RedirectToAction(nameof(Index));

            }

            return View();
        }

        //// GET: Product/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Product/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Product/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Product/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}