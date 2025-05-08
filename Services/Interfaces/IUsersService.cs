using danone_client.Models.DTOs;
using danone_client.Models.Responses;

namespace danone_client.Services.Interfaces
{
    public interface IUsersService
    {
        public Response GetAll();
        public Response GetById(int id);
        public Response GetByEmail(string email);
        public Response Add(RegisterDTO model);
        public Response Update(UserDTO model, string email);
        public Response Delete(int id, string email);
        public Response Data(string email);
    }
}