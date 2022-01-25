using Geesemon.Database.Models;
using Geesemon.Database.Repositories;
using Geesemon.GraphQL.Abstraction;
using Geesemon.GraphQL.Services;
using GraphQL;
using GraphQL.Resolvers;
using GraphQL.Types;

namespace Geesemon.GraphQL.Users
{
    public class UsersSubscriptions : ObjectGraphType, IClientSubscriptionMarker
    {
        private readonly UsersRepository _usersRepository;
        public UsersSubscriptions(UsersRepository usersRepository, UserAddedService userAddedService)
        {
            _usersRepository = usersRepository;

            Name = "UsersSubscribtions";

            //AddField(new EventStreamFieldType
            //{
            //    Name = "userAdded",
            //    Type = typeof(UserType),
            //    Resolver = new FuncFieldResolver<User>(context => context.Source as User),
            //    Subscriber = new EventStreamResolver<User>(context => userAddedService.Subscribe())
            //});

            Field<UserType>()
                .Name("userAdded")
                .Resolve(context => context.Source as User)
                .Subscribe(context => userAddedService.Subscribe());
        }
    }
}
