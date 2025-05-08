using danone_client.Models.DTOs;
using danone_client.Models.Entities;
using danone_client.Models.Responses;
using danone_client.Repositories.Interfaces;
using danone_client.Services.Interfaces;
using danone_client.Tools;
using Microsoft.IdentityModel.Tokens;

namespace danone_client.Services.Implementations
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Response GetById(int id)
        {
            Response response = new Response();
            var user = _usersRepository.GetById(id);
            UserDTO result = new UserDTO(user);
            return new ResponseModel<UserDTO>(200, "Ok", result);
        }

        public Response GetAll()
        {
            Response response = new Response();
            var users = _usersRepository.GetAll();
            var result = users.Select(u => new UserDTO(u)).ToList();
            return new ResponseModel<List<UserDTO>>(200, "Ok", result);
        }

        public Response GetByEmail(string email)
        {
            Response response = new Response();

            var user = _usersRepository.GetByEmail(email);

            if (user == null)
            {
                response.statusCode = 404;
                response.message = "El usuario no fue encontrado";
                return response;
            }

            response = new ResponseModel<User>(200, "Ok", user);
            return response;
        }

        public Response Add(RegisterDTO model)
        {
            Response response = new Response();

            if (model == null
                || model.email.IsNullOrEmpty()
                || model.firstName.IsNullOrEmpty()
                || model.lastName.IsNullOrEmpty()
                || model.password.IsNullOrEmpty())
            {
                response.statusCode = 400;
                response.message = "Formulario inválido";
                return response;
            }

            var user = _usersRepository.GetByEmail(model.email);

            if (user != null)
            {
                response.statusCode = 401;
                response.message = "El email ya esta en uso";
                return response;
            }

            Encrypter.EncryptString(model.password, out byte[] hash, out byte[] salt);

            User newUser = new User();

            newUser.email = model.email;
            newUser.firstName = model.firstName;
            newUser.lastName = model.lastName;
            newUser.role = Models.Enums.Role.USER;
            newUser.hash = hash;
            newUser.salt = salt;

            _usersRepository.Save(newUser);

            response.statusCode = 200;
            response.message = "Ok";
            return response;
        }

        public Response Data(string email)
        {
            Response response = new Response();

            var user = _usersRepository.GetByEmail(email);

            if (user == null)
            {
                response.statusCode = 401;
                response.message = "Sesión invalida";
                return response;
            }

            UserDTO userDTO = new UserDTO(user);

            response = new ResponseModel<UserDTO>(200, "Ok", userDTO);

            return response;
        }

        public Response Update(UserDTO model, string email)
        {
            Response response = new Response();

            if (model.email != email)
            {
                response.statusCode = 401;
                response.message = "No tienes permisos para editar este usuario";
                return response;
            }

            if (model == null
                || model.email.IsNullOrEmpty()
                || model.firstName.IsNullOrEmpty()
                || model.lastName.IsNullOrEmpty())
            {
                response.statusCode = 400;
                response.message = "Formulario inválido";
                return response;
            }

            var user = _usersRepository.GetByEmail(model.email);

            if (user == null)
            {
                response.statusCode = 401;
                response.message = "Usuario no encontrado";
                return response;
            }

            user.firstName = model.firstName;
            user.lastName = model.lastName;

            _usersRepository.Save(user);

            response.statusCode = 200;
            response.message = "Ok";
            return response;
        }

        public Response Delete(int id, string email)
        {
            Response response = new Response();

            var user = _usersRepository.GetById(id);

            if (user.email != email)
            {
                response.statusCode = 401;
                response.message = "No tienes permisos para eliminar este usuario";
                return response;
            }

            if (user == null)
            {
                response.statusCode = 401;
                response.message = "Usuario no encontrado";
                return response;
            }

            _usersRepository.Remove(user);
            response.statusCode = 200;
            response.message = "Ok";
            return response;
        }
    }

}
