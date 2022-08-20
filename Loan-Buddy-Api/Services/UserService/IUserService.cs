using Loan_Buddy_Api.Data;
using Loan_Buddy_Api.DTOs;

namespace Loan_Buddy_Api.Services.UserService
{
    public interface IUserService
    {
        public Task<ServiceResponse<IEnumerable<User>>> GetUsers();
        public Task<ServiceResponse<UserDto>> GetUser(int userId);

    }
}
