using System;
using System.Collections.Generic;
using System.Text;

namespace MVCExample.Models.DTO
{
    public class BasketItemDto
    {
        public int BasketItemId { get; set; }

        public int ProductId { get; set; }
        public int BasketId { get; set; }

    }
}
