using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RazorPageExample.DataAccess
{
    public class ProductType
    {
        [Key]
        public int Id { get; set; }

        [MinLength(1)]
        [MaxLength(20)]
        public string ProductTypeName { get; set; }

        public string ProductTypeDescription { get; set; }
    }
}
