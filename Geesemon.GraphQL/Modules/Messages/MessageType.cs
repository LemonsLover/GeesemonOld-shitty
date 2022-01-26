using Geesemon.Database.Models;
using GraphQL.Types;

namespace Geesemon.GraphQL.Modules.Messages
{
    public class MessageType : ObjectGraphType<Message>
    {
        public MessageType()
        {
            Name = "Message";

            Field<IdGraphType>()
               .Name("Id")
               .Description("Message id.")
               .Resolve(context => context.Source.Id);

            Field<StringGraphType>()
               .Name("Text")
               .Description("Message Text.")
               .Resolve(context => context.Source.Text);

            Field<IntGraphType>()
               .Name("ChatId")
               .Description("Message's chat id.")
               .Resolve(context => context.Source.ChatId);

            Field<IntGraphType>()
               .Name("UserId")
               .Description("Message's user id.")
               .Resolve(context => context.Source.UserId);

            Field<DateTimeGraphType>()
               .Name("CreatedAt")
               .Description("Message's creation date.")
               .Resolve(context => context.Source.CreatedAt);

            Field<DateTimeGraphType>()
               .Name("UpdatedAt")
               .Description("Message's update date.")
               .Resolve(context => context.Source.UpdatedAt);
        }
    }
}
