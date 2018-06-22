using System;
using System.Collections.Generic;
using System.Text;

namespace MVCExample.Models.DTO
{
    public class ProductDto
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ProductTypeDto ProductType { get; set; }

        public Decimal Price { get; set; }
    }
}
