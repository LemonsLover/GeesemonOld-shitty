using Geesemon.Database.Models;
using GraphQL.Types;

namespace Geesemon.GraphQL.Modules.Messages.DTO
{
    public class CreateMessageInputType : InputObjectGraphType<Message>
    {
        public CreateMessageInputType()
        {
            Field<StringGraphType>()
                .Name("Text")
                .Description("Message Text.")
                .Resolve(context => context.Source.Text);
        }
    }
}
