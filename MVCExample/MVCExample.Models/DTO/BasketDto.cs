using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVCExample.Models.DTO
{
    public class BasketDto
    {
        public int BasketId { get; set; }

        public IdentityUser IdentityUser { get; set; }

        public BasketDto Basket { get; set; }
    }
}
