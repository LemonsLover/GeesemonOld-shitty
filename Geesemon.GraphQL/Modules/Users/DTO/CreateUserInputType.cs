using Geesemon.Database.Models;
using GraphQL.Types;

namespace Geesemon.GraphQL.Modules.Users.DTO
{
    public class CreateUserInputType : InputObjectGraphType<User>
    {
        public CreateUserInputType()
        {
            Field(u => u.Email,
                type: typeof(StringGraphType))
                .Description("User Email");
        }
    }
}
