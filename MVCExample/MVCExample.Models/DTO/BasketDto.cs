using System;
using System.Collections.Generic;
using System.Text;

namespace MVCExample.Models.DTO
{
    public class BasketDto
    {
        public int BasketId { get; set; }

        public AccountDto Account { get; set; }
    }
}
