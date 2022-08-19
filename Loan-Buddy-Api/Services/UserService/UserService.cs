using Loan_Buddy_Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Loan_Buddy_Api.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly AppDBContext _db = new AppDBContext();
     
        public async Task<ServiceResponse<User>> GetUser(int userId)
        {
            var serviceResponse = new ServiceResponse<User>();
            var user = await _db.Users.SingleOrDefaultAsync(r => r.UserId == userId);
            serviceResponse.Data = user;

            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<User>>> GetUsers()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<User>>();
            serviceResponse.Data = await _db.Users.ToListAsync();

            return serviceResponse;
        }
    }
}
