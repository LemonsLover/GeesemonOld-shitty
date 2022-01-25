using Geesemon.Database.Models;
using Geesemon.Database.Repositories;
using Geesemon.GraphQL.Abstraction;
using Geesemon.GraphQL.Services;
using Geesemon.GraphQL.Users.DTO;
using GraphQL;
using GraphQL.Types;

namespace Geesemon.GraphQL.Users
{
    public class UsersMutations : ObjectGraphType, IClientMutationMarker
    {
        private readonly UsersRepository _usersRepository;
        public UsersMutations(UsersRepository usersRepository, UserAddedService userAddedService)
        {
            _usersRepository = usersRepository;

            Name = "UsersMutation";

            Field<UserType>()
                .Name("createUser")
                .Argument<CreateUserInputType, User>("createUserInputType", "Argument for create new User")
                .ResolveAsync(async (context) => 
                {
                    User user = context.GetArgument<User>("createUserInputType");
                    user = await _usersRepository.CreateAsync(user);
                    userAddedService.Add(user);
                    return user;
                });
        }
    }
}
