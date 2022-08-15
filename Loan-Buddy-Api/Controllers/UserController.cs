using Loan_Buddy_Api.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Loan_Buddy_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase

    {
        private AppDBContext db = new AppDBContext();

        [HttpGet("GetUsers")]
        public async Task<IEnumerable<User>> GetUsers()

        {
            return db.Users.ToList();
        }

        [HttpGet("GetUser")]
        public async Task<User> GetUser(int userId)

        {                     
            return db.Users.SingleOrDefault(r => r.UserId == userId);
        }



        [HttpGet]
        public string Get()
        {
            return "Joe Turner, turn into JSON object eventually";
        }

    }
}
