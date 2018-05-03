using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RazorPageExample.DataAccess
{
   public  class Basket
    {
        [Key]
        public int Id { get; set; }
        public virtual IEnumerable<Product> Product { get; set; }
        [DataType(DataType.Currency)]
        public long TotalPrice { get; set; }

        public User User { get; set; }
    }
}
