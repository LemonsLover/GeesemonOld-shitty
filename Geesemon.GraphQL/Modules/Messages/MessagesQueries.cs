using Geesemon.Database.Models;
using Geesemon.Database.Repositories;
using Geesemon.GraphQL.Abstraction;
using Geesemon.GraphQL.Modules.Auth;
using Geesemon.GraphQL.Modules.Messages.DTO;
using GraphQL;
using GraphQL.Types;

namespace Geesemon.GraphQL.Modules.Messages
{
    public class MessagesQueries : ObjectGraphType, IQueryMarker
    {
        public MessagesQueries(MessagesRepository messagesRepository)
        {
            Name = "MessagesQueries";

            Field<ListGraphType<MessageType>>()
                .Name("getMessages")
                .Argument<GetMessagesInputType, GetMessagesInput>("getMessagesInputType", "Argument for get messages.")
                .ResolveAsync(async context =>
                {
                    GetMessagesInput getMessagesInput = context.GetArgument<GetMessagesInput>("getMessagesInputType");
                    if (getMessagesInput.Page < 1)
                        throw new System.Exception("Page must be only positive number");
                    if (getMessagesInput.PageSize < 1 || getMessagesInput.PageSize > 30)
                        throw new System.Exception("Page size must be in range 1-30");

                    return await messagesRepository.GetAsync(getMessagesInput.Page, getMessagesInput.PageSize);
                })
                .AuthorizeWith(AuthPolicies.Authenticated);
        }
    }
}
