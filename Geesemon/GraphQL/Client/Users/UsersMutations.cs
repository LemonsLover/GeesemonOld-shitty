using Geesemon.Database.Repositories;
using Geesemon.GraphQL.Client.Abstraction;
using GraphQL.Types;

namespace Geesemon.GraphQL.Client.Users
{
    public class UsersMutations : ObjectGraphType, IClientMutationMarker
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
