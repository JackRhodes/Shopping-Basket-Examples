using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVCExample.Data;
using MVCExample.DataAccess.Contracts;
using MVCExample.Models.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MVCExample.DataAccess.Repositories
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly ApplicationDbContext context;

        public IdentityRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Task<IdentityUser> GetCurrentUserAsync(string accountId)
        {
            return context.Users
                .Where(x => x.Id == accountId)
                .FirstOrDefaultAsync();
        }
    }
}
