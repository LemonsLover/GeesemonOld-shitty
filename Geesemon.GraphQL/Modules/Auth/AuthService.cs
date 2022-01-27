using Geesemon.Database.Models;
using Geesemon.Database.Repositories;
using Geesemon.GraphQL.Modules.Auth.DTO;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Geesemon.GraphQL.Modules.Auth
{
    public class AuthService
    {
        private readonly UsersRepository _usersRepository;

        public AuthService(UsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<string> Authenticate(LoginAuthInput loginAuthInput)
        {
            User user = await _usersRepository.GetByEmailAsync(loginAuthInput.Email);
            if (user == null || user.Password != loginAuthInput.Password)
                throw new Exception("Bad credensials");
            return GenerateAccessToken(user.Id, user.Email, user.Role);

        }

        public string GenerateAccessToken(int userId, string userEmail, RoleEnum userRole)
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("AuthIssuerSigningKey")));
            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>
            {
                new Claim(AuthClaimsIdentity.DefaultIdClaimType, userId.ToString()),
                new Claim(AuthClaimsIdentity.DefaultNameClaimType, userEmail),
                new Claim(AuthClaimsIdentity.DefaultRoleClaimType, userRole.ToString()),
            };
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: Environment.GetEnvironmentVariable("AuthValidIssuer"),
                audience: Environment.GetEnvironmentVariable("AuthValidAudience"),
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: signingCredentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
