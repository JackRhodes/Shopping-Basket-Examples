using Microsoft.AspNetCore.Identity;
using MVCExample.Models.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MVCExample.DataAccess.Contracts
{
    public interface IIdentityRepository
    {
        Task<IdentityUser> GetCurrentUserAsync(string accountId);
    }
}
