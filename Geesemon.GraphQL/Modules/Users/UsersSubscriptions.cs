using Geesemon.Database.Models;
using Geesemon.Database.Repositories;
using Geesemon.GraphQL.Abstraction;
using Geesemon.GraphQL.Services;
using GraphQL.Types;

namespace Geesemon.GraphQL.Modules.Users
{
    public class UsersSubscriptions : ObjectGraphType, ISubscriptionMarker
    {
        private readonly UsersRepository _usersRepository;
        public UsersSubscriptions(UsersRepository usersRepository, UserAddedService userAddedService)
        {
            _usersRepository = usersRepository;

            Name = "UsersSubscribtions";

            Field<UserType>()
                .Name("userAdded")
                .Resolve(context => context.Source as User)
                .Subscribe(context => userAddedService.Subscribe());
        }
    }
}
