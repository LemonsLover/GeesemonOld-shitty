using Geesemon.Database.Models;
using GraphQL.Types;

namespace Geesemon.GraphQL.Modules.Messages
{
    public class MessageType : ObjectGraphType<Message>
    {
        public MessageType()
        {
            Field(c => c.Id, type: typeof(IdGraphType));
            Field(c => c.Text, type: typeof(StringGraphType));
            Field(c => c.ChatId, type: typeof(IntGraphType));
            Field(c => c.UserId, type: typeof(IntGraphType));
            Field(c => c.CreatedAt, type: typeof(DateTimeGraphType));
            Field(c => c.UpdatedAt, type: typeof(DateTimeGraphType));
        }
    }
}
