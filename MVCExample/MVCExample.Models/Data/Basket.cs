using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MVCExample.Models.Data
{
    public class Basket
    {
        [Key]
        public int BasketId { get; set; }

        public IdentityUser IdentityUser { get; set; }
    }
}
