using Geesemon.Database.Repositories;
using Geesemon.GraphQL.Admin.Abstraction;
using GraphQL.Types;

namespace Geesemon.GraphQL.Admin.Users
{
    public class UsersMutations : ObjectGraphType, IAdminMutationMarker
    {
        private readonly UsersRepository _usersRepository;
        public UsersMutations(UsersRepository usersRepository)
        {
            _usersRepository = usersRepository;

            Name = "UsersMutation";

            Field<ListGraphType<UserType>>("createUser", "Create a User", resolve: context => _usersRepository.Create());
        }
    }
}
