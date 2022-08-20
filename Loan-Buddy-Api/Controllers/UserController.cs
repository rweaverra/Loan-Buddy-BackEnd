using Loan_Buddy_Api.Data;
using Loan_Buddy_Api.DTOs;
using Loan_Buddy_Api.Services;
using Loan_Buddy_Api.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Loan_Buddy_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase

    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {          
            _userService = userService;
        }

        [HttpGet("GetUsers")]
        public async Task<ServiceResponse<IEnumerable<User>>> GetUsers()

        {
            return await _userService.GetUsers();
        }

        [HttpGet("{userId}")]
        public async Task<ServiceResponse<UserDto>> GetUser(int userId)

        {
            return await _userService.GetUser(userId);
        }
    }
}
