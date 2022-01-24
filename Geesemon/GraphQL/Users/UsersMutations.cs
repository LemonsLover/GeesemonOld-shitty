using Geesemon.Database.Models;
using Geesemon.Database.Repositories;
using Geesemon.GraphQL.Abstraction;
using Geesemon.GraphQL.Users.DTO;
using GraphQL;
using GraphQL.Types;

namespace Geesemon.GraphQL.Users
{
    public class UsersMutations : ObjectGraphType, IClientMutationMarker
    {
        private readonly UsersRepository _usersRepository;
        public UsersMutations(UsersRepository usersRepository)
        {
            _usersRepository = usersRepository;

            Name = "UsersMutation";

            Field<UserType>()
                .Name("createUser")
                .Description("Create a new User")
                .Argument<CreateUserInputType, User>("createUserInputType", "Argument for create new User")
                .ResolveAsync(async (context) => 
                {
                    User user = context.GetArgument<User>("createUserInputType");
                    return await _usersRepository.Create(user);
                });
        }
    }
}
