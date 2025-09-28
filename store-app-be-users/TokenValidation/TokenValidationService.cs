using Microsoft.EntityFrameworkCore;
using Persistence.DBContext;
using Persistence.Models;

namespace store_app_be_users.TokenValidation
{
    public class TokenValidationService : ITokenValidationService
    {
        private UserDBContext _dbContext;
        public TokenValidationService(UserDBContext dbContext) 
        { 
            _dbContext = dbContext;
        }
        public async Task<User?> GetUserFromRequest(string username, string password)
        {
            return await _dbContext.Users
                .Include(u => u.Roles)
                .FirstOrDefaultAsync(u => u.UserName == username && u.Password == password);
        }
    }
}
