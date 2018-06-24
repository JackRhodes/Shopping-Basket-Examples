using Microsoft.AspNetCore.Identity;
using MVCExample.DataAccess.Contracts;
using MVCExample.Models.Data;
using MVCExample.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MVCExample.Services.Managers
{
    public class AccountManager : IAccountManager
    {
        private readonly IIdentityRepository accountRepository;

        public AccountManager(IIdentityRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        public async Task<IdentityUser> GetCurrentUserAsync(string accountId)
        {
            if (!(String.IsNullOrEmpty(accountId) || String.IsNullOrWhiteSpace(accountId)))
                return await accountRepository.GetCurrentUserAsync(accountId);
            else throw new ArgumentNullException();
        }
    }
}
