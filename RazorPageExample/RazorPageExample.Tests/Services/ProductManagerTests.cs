using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RazorPageExample.DataAccess;
using RazorPageExample.Services;
using RazorPageExample.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorPageExample.Tests.Services
{
    [TestClass]
    public class ProductManagerTests
    {
        private StubDataHelper stubData;

        public ProductManagerTests()
        {
            stubData = new StubDataHelper();
        }

        [TestMethod]
        public void GetProducts_ShouldReturn_IEnumberableOfProduct()
        {
            //Create mock repository
            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
            //Create IENumerable of random products
            Task<IEnumerable<Product>> products = Task<IEnumerable<Product>>.Factory.StartNew(() =>
            {
                return stubData.GenerateRandomProducts(29);
            });
            //Setup repository to return products
            productRepository.Setup(x => x.GetProductsAsync()).Returns(products);
            //Use a real version of product manager with mock repository
            ProductManager productManager = new ProductManager(productRepository.Object);
            //Assert whether all Product items are within the Managers results
            Assert.IsTrue(products.Result.All(productManager.GetProductsAsync().Result.Contains));
            //Assert whether result count is the same
            Assert.AreEqual(products.Result.Count(), products.Result.Intersect(productManager.GetProductsAsync().Result).Count());
        }
        
        [TestMethod]
        public void GetProduct_ShouldReturn_SingularProduct ()
        {
            Mock<IProductRepository> productRepository = new Mock<IProductRepository>();

            Task<Product> product = Task<Product>.Factory.StartNew(() =>
            {
                return stubData.GenerateRandomProduct();
            });

            productRepository.Setup(x => x.GetProductsByIdAsync(It.IsAny<int>())).Returns(product);

            ProductManager productManager = new ProductManager(productRepository.Object);

            Assert.AreEqual(productManager.GetProductsByIdAsync(product.Result.Id).Result.Id, product.Result.Id);

        }

    }
}
