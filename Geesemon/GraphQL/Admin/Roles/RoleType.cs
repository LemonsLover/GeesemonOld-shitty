using Geesemon.Database.Models;
using GraphQL.Types;

namespace Geesemon.GraphQL.Admin.Roles
{
    public class RoleType : ObjectGraphType<Role>
    {
        public RoleType()
        {
            Field(u => u.Id,
                type: typeof(IdGraphType))
                .Description("Role Id");

            Field(u => u.Name,
                type: typeof(StringGraphType))
                .Description("Role Name");
        }
    }
}

