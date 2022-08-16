using Loan_Buddy_Api.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace Loan_Buddy_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase

    {
        private AppDBContext _db = new AppDBContext();

        [HttpGet("GetUsers")]
        public async Task<IEnumerable<User>> GetUsers()

        {
            return await _db.Users.ToListAsync();
        }

        [HttpGet("{userId}")]
        public async Task<User> GetUser(int userId)

        {                     
            return await _db.Users.SingleOrDefaultAsync(r => r.UserId == userId);
        }



        [HttpGet]
        public string Get()
        {
            return "Joe Turner, turn into JSON object eventually";
        }

    }
}
