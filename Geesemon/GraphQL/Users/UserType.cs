using Geesemon.Database.Models;
using GraphQL.Types;

namespace Geesemon.GraphQL.Users
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType()
        {
            Field(u => u.Id,
                type: typeof(IdGraphType))
                .Description("User Id");

            Field(u => u.Email,
                type: typeof(StringGraphType))
                .Description("User Email");
        }
    }
}
