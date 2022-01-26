using Geesemon.Database.Models;
using Geesemon.Database.Repositories;
using Geesemon.GraphQL.Modules.Messages;
using GraphQL.Types;

namespace Geesemon.GraphQL.Modules.Users
{
    public class UserType : ObjectGraphType<User>
    {
        private readonly ChatsRepository _chatsRepository;
        public UserType(ChatsRepository chatsRepository)
        {
            _chatsRepository = chatsRepository;

            Field(u => u.Id, type: typeof(IdGraphType));
            Field(u => u.Email, type: typeof(StringGraphType));
            Field(u => u.Role, type: typeof(RoleEnumType));
            Field(c => c.CreatedAt, type: typeof(DateTimeGraphType));
            Field(c => c.UpdatedAt, type: typeof(DateTimeGraphType));
        }
    }

    public class RoleEnumType : EnumerationGraphType<RoleEnum>
    {
    }
}
