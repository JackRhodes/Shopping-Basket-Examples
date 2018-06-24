using System;
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

            ProductViewModel productCreateViewModel = new ProductViewModel()
            {
                ProductDto = new ProductDto(),

                ProductTypeDtos = productTypeDto.ToList()
            };

            return View(productCreateViewModel);
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("ProductDto,ProductTypeDtos,ProductType")] ProductViewModel productViewModel)
        {

            if (ModelState.IsValid)
            {
                //Refactor when possible
                ProductType productType = await productTypeManager.GetProductTypeByIdAsync(productViewModel.ProductType);

                ProductDto productDto = productViewModel.ProductDto;

                Product product = Mapper.Map<Product>(productDto);

                product.ProductType = productType;

                await productManager.CreateProductAsync(product);

                return RedirectToAction(nameof(Index));

            }

            return View();
        }

        // GET: Product/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                Product product = await productManager.GetProductByIdAsync(id);
                ProductDto productDto = mapper.Map<ProductDto>(product);

                IEnumerable<ProductType> productType = await productTypeManager.GetAllProductTypesAsync();

                IEnumerable<ProductTypeDto> productTypeDto = mapper.Map<IEnumerable<ProductTypeDto>>(productType);

                ProductViewModel productViewModel = new ProductViewModel()
                {
                    ProductDto = productDto,

                    ProductTypeDtos = productTypeDto.ToList()
                };

                return View(productViewModel);
            }

            catch (Exception)
            {
                return RedirectToAction(nameof(this.Index));
            }
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind("ProductDto,ProductTypeDtos,ProductType")] ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                //Refactor when possible
                ProductType productType = await productTypeManager.GetProductTypeByIdAsync(productViewModel.ProductType);

                ProductDto productDto = productViewModel.ProductDto;

                Product product = Mapper.Map<Product>(productDto);

                product.ProductType = productType;

                await productManager.UpdateProductAsync(product);

                return RedirectToAction(nameof(Index));

            }

            return View();
        }

        [HttpGet]
        // GET: Product/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Product product = await productManager.GetProductByIdAsync(id);
                ProductDto productDto = mapper.Map<ProductDto>(product);

                return View(productDto);
            }

            catch (Exception)
            {
                return RedirectToAction(nameof(this.Index));
            }
        }

        // POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int? id)
        {
            Product product = await productManager.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            await productManager.DeleteProductByIdAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}