using Geesemon.Database.Models;
using Geesemon.Database.Repositories;
using Geesemon.GraphQL.Chats;
using GraphQL.Types;

namespace Geesemon.GraphQL.Users
{
    public class UserType : ObjectGraphType<User>
    {
        private readonly ChatsRepository _chatsRepository;
        public UserType(ChatsRepository chatsRepository)
        {
            _chatsRepository = chatsRepository;

            Field(u => u.Id, type: typeof(IdGraphType));

            Field(u => u.Email, type: typeof(StringGraphType));

            Field(u => u.Chats, type: typeof(ListGraphType<ChatType>))
                .Resolve(context =>
                {
                    User user = context.Source;
                    return _chatsRepository.GetByUserId(user.Id);
                });

            Field(c => c.CreatedAt, type: typeof(DateTimeGraphType));

            Field(c => c.UpdatedAt, type: typeof(DateTimeGraphType));
        }
    }
}
