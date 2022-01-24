using Geesemon.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
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
        
        public async Task<User> GetById(int userId)
        {
            return await _ctx.Users.FindAsync(userId);
        }
        
        public async Task<User> Create(User user)
        {
            User checkUser = await _ctx.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
            if (checkUser != null)
                throw new Exception("User with current email already exists");
            _ctx.Users.Add(user);
            await _ctx.SaveChangesAsync();
            return user;
        }
    }
}
