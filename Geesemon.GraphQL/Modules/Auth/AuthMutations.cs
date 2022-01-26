using Geesemon.Database.Repositories;
using Geesemon.GraphQL.Abstraction;
using Geesemon.GraphQL.Modules.Auth.DTO;
using Geesemon.GraphQL.Services;
using GraphQL;
using GraphQL.Types;

namespace Geesemon.GraphQL.Modules.Auth
{
    public class AuthMutations : ObjectGraphType, IMutationMarker
    {
        public AuthMutations(UsersRepository usersRepository, AuthService authService)
        {
            Field<AuthType>()
                .Name("Login")
                .Argument<LoginAuthInputType, LoginAuthInput>("loginAuthInputType", "Argument for login User")
                .ResolveAsync(async (context) =>
                {
                    LoginAuthInput loginAuthInput = context.GetArgument<LoginAuthInput>("loginAuthInputType");
                    return new AuthModel()
                    {
                        Token = await authService.Authenticate(loginAuthInput),
                        User = await usersRepository.GetByEmailAsync(loginAuthInput.Email),
                    };
                });
        }
    }
}
