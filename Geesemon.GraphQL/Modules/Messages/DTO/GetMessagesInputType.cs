using Geesemon.GraphQL.Abstraction;
using GraphQL.Types;

namespace Geesemon.GraphQL.Modules.Messages.DTO
{
    public class GetMessagesInputType : InputObjectGraphType<GetMessagesInput>
    {
        public GetMessagesInputType()
        {
            Field(i => i.Page)
                .Description("Message page number.");

            Field(i => i.PageSize)
                .Description("Message page size.");
        }
    }
}
