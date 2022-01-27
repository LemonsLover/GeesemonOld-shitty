using Geesemon.Database.Models;
using GraphQL.Types;

namespace Geesemon.GraphQL.Modules.Users
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType()
        {
            Name = "User";

            Field<IdGraphType>()
               .Name("Id")
               .Description("User id.")
               .Resolve(context => context.Source.Id);

            Field<StringGraphType>()
               .Name("Email")
               .Description("User Email.")
               .Resolve(context => context.Source.Email);

            Field<RoleEnumType>()
               .Name("Role")
               .Description("User role.")
               .Resolve(context => context.Source.Role);

            Field<DateTimeGraphType>()
               .Name("CreatedAt")
               .Description("User creation date.")
               .Resolve(context => context.Source.CreatedAt);

            Field<DateTimeGraphType>()
               .Name("UpdatedAt")
               .Description("User update date.")
               .Resolve(context => context.Source.UpdatedAt);
        }
    }

    public class RoleEnumType : EnumerationGraphType<RoleEnum>
    {
    }
}
