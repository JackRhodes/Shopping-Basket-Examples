using MVCExample.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVCExample.Models.ViewModel
{
    public class BasketViewModel
    {
        public IEnumerable<ProductDto> BasketItems { get; set; }
    }
}
