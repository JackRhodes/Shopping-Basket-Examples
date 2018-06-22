using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MVCExample.Models.Data
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }

        public ProductType ProductType { get; set; }

        public Decimal Price { get; set; }
    }
}
