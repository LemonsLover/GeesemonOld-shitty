using Geesemon.Database.Models;
using GraphQL.Types;

namespace Geesemon.GraphQL.Modules.Auth.DTO
{
    public class LoginAuthInputType : InputObjectGraphType<LoginAuthInput>
    {
        public LoginAuthInputType()
        {
            Field(l => l.Email, type: typeof(StringGraphType));
            Field(l => l.Password, type: typeof(StringGraphType));
        }
    }
}
