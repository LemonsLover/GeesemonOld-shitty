using Geesemon.Database.Repositories;
using Geesemon.GraphQL.Admin.Abstraction;
using GraphQL.Types;

namespace Geesemon.GraphQL.Admin.Roles
{
    public class RolesMutations : ObjectGraphType, IAdminMutationMarker
    {
        private readonly RolesRepository _rolesRepository;
        public RolesMutations(RolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;

            Name = "RolesMutation";

            Field<ListGraphType<RoleType>>("createRole", "Create a Role", resolve: context => _rolesRepository.Create());
        }
    }
}
