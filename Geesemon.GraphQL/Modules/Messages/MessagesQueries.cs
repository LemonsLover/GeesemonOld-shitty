using Geesemon.Database.Models;
using Geesemon.Database.Repositories;
using Geesemon.GraphQL.Abstraction;
using Geesemon.GraphQL.Modules.Auth;
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
                .ResolveAsync(async context => await messagesRepository.GetAsync())
                .AuthorizeWith(AuthPolicies.Authenticated);
        }
    }
}
