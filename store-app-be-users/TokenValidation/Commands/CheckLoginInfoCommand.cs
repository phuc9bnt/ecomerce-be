using MediatR;
using Persistence.DTOs;

namespace store_app_be_users.TokenValidation.Commands
{
    public class CheckLoginInfoCommand : IRequest<LoginResponseDto>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
