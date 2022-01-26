using Geesemon.Database.Repositories;
using Geesemon.GraphQL.Abstraction;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Geesemon.GraphQL.Modules.Chats
{
    public class ChatsQueries : ObjectGraphType, IQueryMarker
    {
        public ChatsQueries(ChatsRepository chatsRepository, IHttpContextAccessor httpContextAccessor)
        {
            Field<ListGraphType<ChatType>>()
                .Name("getMyChats")
                .ResolveAsync(async context =>
                {
                    string userUmail = httpContextAccessor.HttpContext.User.Identity.Name;
                    return await chatsRepository.GetMyAsync(userUmail, 1, 10);
                })
                .AuthorizeWith("Authenticated");
        }
    }
}
