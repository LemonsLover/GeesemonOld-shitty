using Geesemon.Database.Repositories;
using Geesemon.GraphQL.Abstraction;
using GraphQL.Types;

namespace Geesemon.GraphQL.Modules.Users
{
    public class UsersQueries : ObjectGraphType, IQueryMarker
    {
        public UsersQueries(UsersRepository usersRepository)
        {
            Name = "UsersQuery";

            Field<ListGraphType<UserType>>()
                .Name("getUsers")
                .ResolveAsync(async context => await usersRepository.GetAsync());
        }
    }
}
