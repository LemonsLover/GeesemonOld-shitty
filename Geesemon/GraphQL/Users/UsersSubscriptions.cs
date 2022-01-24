using Geesemon.Database.Models;
using Geesemon.Database.Repositories;
using Geesemon.GraphQL.Abstraction;
using GraphQL;
using GraphQL.Resolvers;
using GraphQL.Subscription;
using GraphQL.Types;
using System;

namespace Geesemon.GraphQL.Users
{
    public class UsersSubscriptions : ObjectGraphType, IClientSubscriptionMarker
    {
        private readonly UsersRepository _usersRepository;
        public UsersSubscriptions(UsersRepository usersRepository)
        {
            _usersRepository = usersRepository;

            Name = "UsersSubscribtions";

            AddField(new EventStreamFieldType
            {
                Name = "userAdded",
                Arguments = new QueryArguments(
                        new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }
                    ),
                Type = typeof(UserType),
                Resolver = new FuncFieldResolver<User>(ResolveUser),
                Subscriber = new EventStreamResolver<User>(Subscribe)
            });
        }

        private User ResolveUser(IResolveFieldContext context)
        {
            return context.Source as User;
        }

        private IObservable<User> Subscribe(IResolveEventStreamContext arg)
        {
            int id = arg.GetArgument<int>("id");
            var a = _usersRepository.SubscribeCreate();
            return a;
        }
    }
}
