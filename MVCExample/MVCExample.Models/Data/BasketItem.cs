﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MVCExample.Models.Data
{
    public class BasketItem
    {
        [Key]
        public int BasketItemId { get; set; }

        public Product Product {get;set;}

    }
}
