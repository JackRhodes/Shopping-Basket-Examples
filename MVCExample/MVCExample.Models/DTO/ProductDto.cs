using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MVCExample.Models.DTO
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        [StringLength(30, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }
        [StringLength(60, MinimumLength = 5)]
        public string Description { get; set; }

        public ProductTypeDto ProductType { get; set; }

        public Decimal Price { get; set; }
    }
}
