using Geesemon.Database.Models;
using Geesemon.Database.Repositories;
using Geesemon.GraphQL.Abstraction;
using Geesemon.GraphQL.Modules.Users.DTO;
using GraphQL;
using GraphQL.Types;

namespace Geesemon.GraphQL.Modules.Users
{
    public class UsersMutations : ObjectGraphType, IMutationMarker
    {
        public UsersMutations(UsersRepository usersRepository, UsersService usersService)
        {
            Name = "UsersMutation";

            Field<UserType>()
                .Name("createUser")
                .Argument<CreateUserInputType, User>("createUserInputType", "Argument for create new User")
                .ResolveAsync(async (context) => 
                {
                    User user = context.GetArgument<User>("createUserInputType");
                    user = await usersRepository.CreateAsync(user);
                    usersService.AddUser(user);
                    return user;
                });
        }
    }
}
