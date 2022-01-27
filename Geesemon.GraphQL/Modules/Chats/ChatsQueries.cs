using Geesemon.Database.Repositories;
using Geesemon.GraphQL.Abstraction;
using Geesemon.GraphQL.Modules.Auth;
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
                    string userId = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == AuthClaimsIdentity.DefaultIdClaimType)?.Value;
                    return await chatsRepository.GetMyAsync(int.Parse(userId), 1, 10);
                })
                .AuthorizeWith(AuthPolicies.Authenticated);
        }
    }
}
