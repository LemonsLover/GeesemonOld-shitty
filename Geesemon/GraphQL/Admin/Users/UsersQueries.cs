using Geesemon.Database.Repositories;
using Geesemon.GraphQL.Admin.Abstraction;
using GraphQL.Types;

namespace Geesemon.GraphQL.Admin.Users
{
    public class UsersQueries : ObjectGraphType, IAdminQueryMarker
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
