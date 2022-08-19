using Loan_Buddy_Api.Data;

namespace Loan_Buddy_Api.Services.UserService
{
    public interface IUserService
    {
        public Task<ServiceResponse<IEnumerable<User>>> GetUsers();
        public Task<ServiceResponse<User>> GetUser(int userId);

    }
}
