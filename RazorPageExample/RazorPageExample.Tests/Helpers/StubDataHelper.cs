using RazorPageExample.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RazorPageExample.Tests.Helpers
{
    class StubDataHelper
    {
        public StubDataHelper()
        {
            random = new Random();
        }

        Random random;

        public string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public int GenerateRandomInt(int min = int.MinValue, int max = int.MaxValue)
        {
            return random.Next() * (max - min) + min;
        }

        public double GenerateRandomDouble(Double min = 0, Double max = 99999999)
        {
            return random.NextDouble() * (max - min) + min;
        }

        public decimal GenerateRandomDecimal(Double min = 0, Double max = 99999999)
        {
            double doubleValue = random.NextDouble() * (max - min) + min;

            return Convert.ToDecimal(doubleValue.ToString());
        }

        public Product GenerateRandomProduct() => new Product()
        {
            Id = random.Next(),
            Description = GenerateRandomString(20),
            Name = $"Product {GenerateRandomString(5)}",
            Price = GenerateRandomDecimal(),
            ProductType = new ProductType()
            {
                Id = GenerateRandomInt(),
                ProductTypeDescription = GenerateRandomString(20),
                ProductTypeName = GenerateRandomString(20)
            }

        };

        public IEnumerable<Product> GenerateRandomProducts(int count = 1)
        {
            List<Product> products = new List<Product>();

            for (int i = 0; i < count; i++)
            {
                products.Add(GenerateRandomProduct());
            }
            return products;        
        }

    }
}
