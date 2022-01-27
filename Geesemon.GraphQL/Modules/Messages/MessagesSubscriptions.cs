using Geesemon.Database.Models;
using Geesemon.Database.Repositories;
using Geesemon.GraphQL.Abstraction;
using GraphQL.Types;

namespace Geesemon.GraphQL.Modules.Messages
{
    public class MessagesSubscriptions : ObjectGraphType, ISubscriptionMarker
    {
        public MessagesSubscriptions(MessagesRepository usersRepository, MessagesService messagesService)
        {
            Name = "MessagesSubscriptions";

            Field<MessageType>()
                .Name("messageAdded")
                .Resolve(context => context.Source as Message)
                .Subscribe(context => messagesService.MessageAddedSubscribe());
        }
    }
}
