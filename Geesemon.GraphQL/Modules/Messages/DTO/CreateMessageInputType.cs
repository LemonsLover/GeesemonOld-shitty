using Geesemon.Database.Models;
using GraphQL.Types;

namespace Geesemon.GraphQL.Modules.Messages.DTO
{
    public class CreateMessageInputType : InputObjectGraphType<Message>
    {
        public CreateMessageInputType()
        {
            Field(m => m.Text)
                .Description("Message Text.");
        }
    }
}
