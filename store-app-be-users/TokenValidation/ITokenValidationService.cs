using Persistence.Models;

namespace store_app_be_users.TokenValidation
{
    public interface ITokenValidationService
    {
        public Task<User?> GetUserFromRequest(string username, string password);
    }
}
