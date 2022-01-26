using Geesemon.Database.Repositories;
using Geesemon.GraphQL.Abstraction;
using GraphQL.Types;

namespace Geesemon.GraphQL.Modules.Users
{
    public class UsersQueries : ObjectGraphType, IQueryMarker
    {
        private readonly UsersRepository _usersRepository;
        public UsersQueries(UsersRepository usersRepository)
        {
            _usersRepository = usersRepository;

            Name = "UsersQuery";

            //Field<ListGraphType<UserType>>("getUsers", "Returns a list of Users", resolve: context => _usersRepository.Get());

            Field<ListGraphType<UserType>>()
                .Name("getUsers")
                .ResolveAsync(async context => await _usersRepository.GetAsync());
        }
    }
}
