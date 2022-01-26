using Geesemon.Database.Models;
using GraphQL.Types;

namespace Geesemon.GraphQL.Modules.Chats
{
    public class ChatType : ObjectGraphType<Chat>
    {
        public ChatType()
        {
            Field(c => c.Id, type: typeof(IdGraphType));
            Field(c => c.Name, type: typeof(StringGraphType));
            Field(c => c.Type, type: typeof(TypeEnum));
            Field(c => c.CreatedAt, type: typeof(DateTimeGraphType));
            Field(c => c.UpdatedAt, type: typeof(DateTimeGraphType));
        }
    }

    public class TypeEnum : EnumerationGraphType<Type>
    {
    }
}
