using Geesemon.GraphQL.Modules.Users;
using GraphQL.Types;

namespace Geesemon.GraphQL.Modules.Auth
{
    public class AuthType : ObjectGraphType<AuthModel>
    {
        public AuthType()
        {
            Field(a => a.User, type: typeof(UserType));
            Field(a => a.Token, type: typeof(StringGraphType));
        }
    }
}
