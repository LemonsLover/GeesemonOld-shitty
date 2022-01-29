using Geesemon.Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geesemon.Database.Repositories
{
    public class MessagesRepository
    {
        private readonly AppDatabaseContext _ctx;

        public MessagesRepository(AppDatabaseContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<Message>> GetAsync(int page = 1, int pageSize = 30)
        {
            return await _ctx.Messages.OrderByDescending(m => m.CreatedAt)
                .Skip((page - 1) * pageSize).Take(pageSize)
                .OrderBy(m => m.CreatedAt)
                .ToListAsync();
        }

        public async Task<Message> GetByIdAsync(int messageId)
        {
            return await _ctx.Messages.FindAsync(messageId);
        }

        public async Task<Message> CreateAsync(Message message, int userId, int chatId)
        {
            message.UserId = userId;
            message.ChatId = chatId;
            _ctx.Messages.Add(message);
            await _ctx.SaveChangesAsync();
            return message;
        }
    }
}
