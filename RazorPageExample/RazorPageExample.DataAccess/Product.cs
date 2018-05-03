using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPageExample.DataAccess
{
    public class Product
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [MaxLength(20), MinLength(1)]
        public string Name { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Currency)]
        public int Price { get; set; }

        public ProductType ProductType { get; set; }

    }
}
