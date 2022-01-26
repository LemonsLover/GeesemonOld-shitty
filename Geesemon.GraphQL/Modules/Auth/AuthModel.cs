using Geesemon.Database.Models;

namespace Geesemon.GraphQL.Modules.Auth
{
    public class AuthModel
    {
        public User User { get; set; }
        public string Token { get; set; }
    }
}
