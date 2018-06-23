using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVCExample.DataAccess.Contracts;
using MVCExample.Models.Data;
using MVCExample.Services.Contracts;
using MVCExample.Services.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCExample.Tests.Services.Managers
{
    [TestClass]
    public class ProductManagerTests
    {

        private IProductManager productManager;
        private IEnumerable<Product> mockProductResponse;
        private Product mockProduct;

        [TestInitialize]
        public void TestSetup()
        {

            ProductType productType = new ProductType()
            {
                Name = "Dairy",
                ProductTypeId = 1
            };

            mockProductResponse = new List<Product>()
            {

                new Product()
                {
                    ProductId = 1,
                    Description = "First product in a list of many",
                    Name = "Product One",
                    Price = 3999,
                    ProductType = productType
                },
                 new Product()
                {
                    ProductId = 2,
                    Description = "Second product in a list of many",
                    Name = "Product Two",
                    Price = 3999,
                    ProductType = productType
                },
                  new Product()
                {
                    ProductId = 3,
                    Description = "Third product in a list of many",
                    Name = "Product Three",
                    Price = 3999,
                    ProductType = productType
                },
                   new Product()
                {
                    ProductId = 4,
                    Description = "Fourth product in a list of many",
                    Name = "Product Four",
                    Price = 3999,
                    ProductType = productType
                }
            };

            mockProduct = new Product()
            {
                ProductId = 1,
                Description = "Mock product",
                Name = "Mock Product",
                Price = 340,
                ProductType = productType
            };

            Mock<IProductRepository> mockProductRepository = new Mock<IProductRepository>();

            mockProductRepository.Setup(x => x.FuzzySearchProductByName(It.IsAny<string>()))
                .Returns(mockProductResponse);

            mockProductRepository.Setup(x => x.GetProductByIdAsync(It.IsAny<int>())).ReturnsAsync(mockProduct);

            productManager = new ProductManager(mockProductRepository.Object);
        }

        [TestMethod]
        public void GetFuzzySearchAsync_ShouldReturnListOfProducts_WhenValidSearch()
        {
            Assert.AreEqual(mockProductResponse.Count(), productManager.FuzzySearchProductByName("Product").Result?.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetFuzzySearchAsync_ShouldReturnException_WhenNullSearch()
        {
            productManager.FuzzySearchProductByName(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetFuzzySearchAsync_ShouldReturnException_WhenWhiteSpaceSearch()
        {
            productManager.FuzzySearchProductByName(String.Empty);
        }

        [TestMethod]
        public void GetProductByIdAsync_ShouldReturnProduct_WhenIdPassed()
        {
            ReferenceEquals(mockProduct, productManager.GetProductByIdAsync(It.IsAny<int>()));
        }

    }
}
