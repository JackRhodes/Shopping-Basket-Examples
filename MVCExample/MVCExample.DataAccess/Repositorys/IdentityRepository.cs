using Microsoft.AspNetCore.Identity;
using MVCExample.Data;
using MVCExample.DataAccess.Contracts;
using MVCExample.Models.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MVCExample.DataAccess.Repositorys
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly ApplicationDbContext context;

        public IdentityRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IdentityUser> GetCurrentUserAsync(string accountId)
        {
            var task = Task.Run(() => context.Users.Where(x => x.Id == accountId).FirstOrDefault());
            return await task;
        }
    }
}
