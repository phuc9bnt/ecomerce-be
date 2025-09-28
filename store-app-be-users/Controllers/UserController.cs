using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence.DTOs;
using store_app_be_users.TokenValidation;
using System.Threading.Tasks;

namespace store_app_be_users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IMediator mediator) : ControllerBase
    {
        [HttpGet("Login")]
        public async Task<LoginResponseDto> Login(string username, string password)
        {
            return await mediator.Send(new TokenValidation.Commands.CheckLoginInfoCommand
            {
                UserName = username,
                Password = password
            });

        }
    }
}
