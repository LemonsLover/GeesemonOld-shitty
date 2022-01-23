using Geesemon.Database.Repositories;
using Geesemon.GraphQL.Admin.Abstraction;
using GraphQL.Types;

namespace Geesemon.GraphQL.Admin.Roles
{
    public class RolesQueries : ObjectGraphType, IAdminQueryMarker
    {
        private readonly RolesRepository _rolesRepository;
        public RolesQueries(RolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;

            Name = "RolesQuery";

            Field<ListGraphType<RoleType>>("getRoles", "Returns a list of Roles", resolve: context => _rolesRepository.Get());
        }
    }
}
