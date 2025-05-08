using danone_client.Models.DTOs;
using danone_client.Models.Entities;
using danone_client.Models.Responses;

namespace danone_client.Services.Interfaces
{
    public interface IAuthService
    {
        public Response Login(LoginDTO model, User user);
        public string MakeToken(string email, string role, int minutes);
    }
}
