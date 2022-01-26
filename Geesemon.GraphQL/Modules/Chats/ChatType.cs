using Geesemon.Database.Models;
using GraphQL.Types;

namespace Geesemon.GraphQL.Modules.Chats
{
    public class ChatType : ObjectGraphType<Chat>
    {
        public ChatType()
        {
            Name = "Chat";

            Field<IdGraphType>()
                .Name("Id")
                .Description("Chat id.")
                .Resolve(context => context.Source.Id);

            Field<StringGraphType>()
                .Name("Id")
                .Description("Chat name.")
                .Resolve(context => context.Source.Name);

            Field<TypeEnum>()
                .Name("Type")
                .Description("Chat Type.")
                .Resolve(context => context.Source.Type);

            Field<DateTimeGraphType>()
                .Name("CreateAt")
                .Description("Chat creation date.")
                .Resolve(context => context.Source.CreatedAt);

            Field<DateTimeGraphType>()
               .Name("UpdatedAt")
               .Description("Chat update date.")
               .Resolve(context => context.Source.UpdatedAt);
        }
    }

    public class TypeEnum : EnumerationGraphType<Type>
    {
    }
}
