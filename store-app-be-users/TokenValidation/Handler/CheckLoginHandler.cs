using MediatR;
using Persistence.DTOs;
using store_app_be_users.TokenValidation.Commands;

namespace store_app_be_users.TokenValidation.Handler
{
    public class CheckLoginHandler : IRequestHandler<CheckLoginInfoCommand, LoginResponseDto>
    {
        private readonly ITokenValidationService _tokenValidationService;
        public CheckLoginHandler(ITokenValidationService tokenValidationService) 
        {
            _tokenValidationService = tokenValidationService;
        }
        public async Task<LoginResponseDto> Handle(CheckLoginInfoCommand request, CancellationToken cancellationToken)
        {
            var result = new LoginResponseDto();
            var user = await _tokenValidationService.GetUserFromRequest(request.UserName, request.Password);
            if (user != null)
            {
                result.AccessToken = "Access";
                result.RefreshToken = "Refresh";
            }
            return result;
        }
    }
}
