using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MVCExample.Models.Data
{
    public class ProductType
    {
        [Key]
        public int ProductTypeId { get; set; }
        public string Name { get; set; }
    }
}
