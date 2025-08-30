using messanger.AuthenticationOptions;
using messanger.Models;
using messanger.Repositories;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace messanger.Services
{
    public class AccountService
    {
        private readonly AccountRepository repository;

        public AccountService(AccountRepository _repository)
        {
            repository = _repository;
        }
        public async Task<string?> GetAuthAsync(string login, string password)
        {
            var person = await repository.GetAuthAsync(login, password);

            if (person is null) return null;

            var claims = new List<Claim> {new Claim(ClaimTypes.NameIdentifier, person.Id.ToString()) };
            var jwt = new JwtSecurityToken(
                issuer: AuthenticationOptions.AuthenticationOptions.ISSUER,
                audience: AuthenticationOptions.AuthenticationOptions.AUDIENCE,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromDays(30)),
                signingCredentials: new SigningCredentials(AuthenticationOptions.AuthenticationOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
        public async Task<int?> NewAccountAsync(string login, string password)
        {

            return await repository.NewAccountAsync(new Account { Login = login, Password = password });
        }
    }
}
