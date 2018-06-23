using MVCExample.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MVCExample.Models.ViewModel
{
    public class ProductViewModel
    {
        [Required]
        public ProductDto ProductDto { get; set; }
        public List<ProductTypeDto> ProductTypeDtos { get; set; }

        public int ProductType { get; set; }

    }
}
