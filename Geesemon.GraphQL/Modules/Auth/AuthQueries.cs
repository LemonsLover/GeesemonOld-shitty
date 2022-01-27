using Geesemon.Database.Models;
using Geesemon.Database.Repositories;
using Geesemon.GraphQL.Abstraction;
using Geesemon.GraphQL.Modules.Auth.DTO;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;

namespace Geesemon.GraphQL.Modules.Auth
{
    public class AuthQueries : ObjectGraphType, IQueryMarker
    {
        public AuthQueries(UsersRepository usersRepository, IHttpContextAccessor httpContextAccessor, AuthService authService)
        {
            Name = "AuthQueries";

            Field<AuthResponseType>()
                .Name("isAuth")
                .ResolveAsync(async context => 
                {
                    string userEmail = httpContextAccessor.HttpContext.User.Identity.Name;
                    User currentUser = await usersRepository.GetByEmailAsync(userEmail);
                    return new AuthModel()
                    {
                        Token = authService.GenerateAccessToken(currentUser.Id, currentUser.Email, currentUser.Role),
                        User = currentUser,
                    };
                })
                .AuthorizeWith(AuthPolicies.Authenticated);
        }
    }
}
