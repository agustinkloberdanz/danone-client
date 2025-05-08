using danone_client.Models.DTOs;
using danone_client.Models.Entities;
using danone_client.Models.Responses;
using danone_client.Repositories.Interfaces;
using danone_client.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;

namespace danone_client.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUsersRepository _userRepository;
        private readonly IAuthService _authService;

        public AuthController(IUsersRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        [HttpPost("login")]
        public ActionResult<AnyType> Login([FromBody] LoginDTO model)
        {
            Response response = new Response();

            try
            {
                if(String.IsNullOrEmpty(model.email) || String.IsNullOrEmpty(model.password))
                {
                    response.statusCode = 400;
                    response.message = "Campos invalidos";
                    return new JsonResult(response);
                }

                User user = _userRepository.GetByEmail(model.email);

                response = _authService.Login(model, user);

                if (response.statusCode != 200)
                    return new JsonResult(response);

                string token = _authService.MakeToken(user.email, user.role.ToString(), 100);

                response = new ResponseModel<string>(200, "Ok", token);

                return new JsonResult(response);
            }
            catch (Exception e)
            {
                response.statusCode = 500;
                response.message = e.Message;

                return new JsonResult(response);
            }
        }

    }
}
