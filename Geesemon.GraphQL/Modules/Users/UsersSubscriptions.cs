using Geesemon.Database.Models;
using Geesemon.Database.Repositories;
using Geesemon.GraphQL.Abstraction;
using GraphQL.Types;

namespace Geesemon.GraphQL.Modules.Users
{
    public class UsersSubscriptions : ObjectGraphType, ISubscriptionMarker
    {
        public UsersSubscriptions(UsersRepository usersRepository, UsersService usersService)
        {
            Name = "UsersSubscribtions";

            Field<UserType>()
                .Name("userAdded")
                .Resolve(context => context.Source as User)
                .Subscribe(context => usersService.UserAddedSubscribe());
        }
    }
}
