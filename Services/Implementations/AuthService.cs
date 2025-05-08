using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using danone_client.Models.DTOs;
using danone_client.Models.Entities;
using danone_client.Models.Responses;
using danone_client.Repositories.Interfaces;
using danone_client.Services.Interfaces;
using danone_client.Tools;
using Microsoft.IdentityModel.Tokens;

namespace danone_client.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IUsersRepository _usersRepository;

        public AuthService(IConfiguration configuration, IUsersRepository usersRepository)
        {
            _configuration = configuration;
            _usersRepository = usersRepository;
        }

        public Response Login(LoginDTO model, User user)
        {
            Response response = new Response();

            if (user == null)
            {
                response.statusCode = 401;
                response.message = "Credenciales invalidas";
                return response;
            }

            if (!(Encrypter.ValidateText(model.password, user.hash, user.salt)))
            {
                response.statusCode = 401;
                response.message = "Contraseña incorrecta";
                return response;
            }

            response.statusCode = 200;
            response.message = "Ok";
            return response;
        }

        public string MakeToken(string email, string role, int minutes)

        {
            var claims = new[]
                {
                    new Claim("Account", email),
                    new Claim("Role", role)
                };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JWT:Key").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(minutes),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }

    }
}
