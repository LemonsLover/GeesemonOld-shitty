using Geesemon.Database.Models;
using Geesemon.Database.Repositories;
using Geesemon.GraphQL.Abstraction;
using Geesemon.GraphQL.Modules.Auth;
using Geesemon.GraphQL.Modules.Messages.DTO;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Geesemon.GraphQL.Modules.Messages
{
    public class MessagesMutations : ObjectGraphType, IMutationMarker
    {
        public MessagesMutations(MessagesRepository messagesRepository, MessagesService messagesService, IHttpContextAccessor httpContextAccessor)
        {
            Name = "UsersMutation";

            Field<MessageType>()
                .Name("createMessage")
                .Argument<CreateMessageInputType, Message>("createMessageInputType", "Argument for create new Message")
                .ResolveAsync(async (context) =>
                {
                    Message message = context.GetArgument<Message>("createMessageInputType");
                    string userId = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == AuthClaimsIdentity.DefaultIdClaimType)?.Value;
                    message = await messagesRepository.CreateAsync(message, int.Parse(userId), 1);
                    messagesService.AddMessage(message);
                    return message;
                })
                .AuthorizeWith(AuthPolicies.Authenticated);
        }
    }
}
