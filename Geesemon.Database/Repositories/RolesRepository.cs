using Geesemon.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geesemon.Database.Repositories
{
    public class RolesRepository
    {
        private readonly AppDatabaseContext _ctx;
        public RolesRepository(AppDatabaseContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<Role>> GetAsync()
        {
            return await _ctx.Roles.ToListAsync();
        }
        
        public async Task<Role> CreateAsync()
        {
            return null;
        }
    }
}
