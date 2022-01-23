using Geesemon.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geesemon.Database.Repositories
{
    public class UsersRepository
    {
        private readonly AppDatabaseContext _ctx;
        public UsersRepository(AppDatabaseContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<User>> Get()
        {
            return await _ctx.Users.ToListAsync();
        }
        
        public async Task<User> Create()
        {
            return null;
        }
    }
}
