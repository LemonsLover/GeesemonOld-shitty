using Geesemon.Database.Repositories;
using Geesemon.GraphQL.Client.Abstraction;
using GraphQL.Types;

namespace Geesemon.GraphQL.Client.Users
{
    public class UsersQueries : ObjectGraphType, IClientQueryMarker
    {
        private readonly UsersRepository _usersRepository;
        public UsersQueries(UsersRepository usersRepository)
        {
            _usersRepository = usersRepository;

            Name = "UsersQuery";

            Field<ListGraphType<UserType>>("getUsers", "Returns a list of Users", resolve: context => _usersRepository.Get());
        }
    }
}
