using Geesemon.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geesemon.Database.Repositories
{
    public class ChatsRepository
    {
        private readonly AppDatabaseContext _ctx;

        public ChatsRepository(AppDatabaseContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<Chat>> GetMyAsync(int userId, int page = 1, int pageSize = 10)
        {
            return await _ctx.Chats.Include(c => c.Users).Where(c => c.Users.Any(u => u.Id == userId)).Take(pageSize).Skip((page - 1) * pageSize).ToListAsync();
        }

        public async Task<Chat> GetByIdAsync(int chatId)
        {
            return await _ctx.Chats.FindAsync(chatId);
        }

        public async Task<Chat> CreateAsync(Chat chat)
        {
            _ctx.Chats.Add(chat);
            await _ctx.SaveChangesAsync();
            return chat;
        }
        
        public IEnumerable<Chat> GetByUserId(int userId)
        {
            User user = _ctx.Users.Include(u => u.Chats).FirstOrDefault(u => u.Id == userId);
            return user.Chats;
           
        }
    }
}
