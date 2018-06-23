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
    public class ProductTypeManagerTests
    {

        private IProductTypeManager productTypeManager;
        private IEnumerable<ProductType> mockProductTypeResponse;

        [TestInitialize]
        public void TestSetup()
        {
            mockProductTypeResponse = new List<ProductType>
            {
                new ProductType()
                {
                    Name = "Dairy",
                    ProductTypeId = 1
                },
                new ProductType()
                {
                    Name = "Poultry",
                    ProductTypeId = 2
                },
                new ProductType()
                {
                    Name = "Smelly",
                    ProductTypeId = 3
                },
                new ProductType()
                {
                    Name = "Bobby",
                    ProductTypeId = 4
                },
            };

            Mock<IProductTypeRepository> mockProductTypeRepository = new Mock<IProductTypeRepository>();
            mockProductTypeRepository.Setup(x => x.GetAllProductTypesAsync()).ReturnsAsync(mockProductTypeResponse);

            productTypeManager = new ProductTypeManager(mockProductTypeRepository.Object);

        }

        [TestMethod]
        public void GetAllProductTypesAsync_ShouldReturn_AllProducts()
        {
            Assert.AreEqual(mockProductTypeResponse.Count(), productTypeManager.GetAllProductTypesAsync().Result.Count());
        }

    }
}
