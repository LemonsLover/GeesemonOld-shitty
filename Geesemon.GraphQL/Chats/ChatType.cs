using Geesemon.Database.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geesemon.GraphQL.Chats
{
    public class ChatType : ObjectGraphType<Chat>
    {
        public ChatType()
        {
            Field(c => c.Id, type: typeof(IdGraphType));

            Field(c => c.Name, type: typeof(StringGraphType));

            Field(c => c.CreatedAt, type: typeof(DateTimeGraphType));

            Field(c => c.UpdatedAt, type: typeof(DateTimeGraphType));
        }
    }
}
