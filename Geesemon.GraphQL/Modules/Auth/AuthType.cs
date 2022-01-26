using Geesemon.GraphQL.Modules.Users;
using GraphQL.Types;

namespace Geesemon.GraphQL.Modules.Auth
{
    public class AuthType : ObjectGraphType<AuthModel>
    {
        public AuthType()
        {
            Name = "Auth";

            Field<UserType>()
                .Name("User")
                .Description("User type")
                .Resolve(context => context.Source.User);

            Field<StringGraphType>()
                .Name("Token")
                .Description("Token type")
                .Resolve(context => context.Source.Token);
        }
    }
}
