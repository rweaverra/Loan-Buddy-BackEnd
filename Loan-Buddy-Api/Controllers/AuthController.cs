using Loan_Buddy_Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Loan_Buddy_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private AppDBContext _db = new AppDBContext();

        [HttpGet()]
        public async Task<ActionResult> Login(string username, string password)
        {
            //grab User based on username
            var user = await _db.Users.Where(u => u.Email == username).FirstOrDefaultAsync();

            if (user is null)
                return BadRequest("no user found");

            if (user.Password == password)
                return Ok(user.UserId);
            else
                return BadRequest("password doesn't match");
            // if the password matches return OK
        }


        [HttpPost]
        public async Task<ActionResult<int>> Register(User user, string password)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return Ok(user.UserId);
        }


        //public async Task<ActionResult<string>> Login(string userName, string password)
        //{
        //    var result = await _authRepo.Login(userName, password);

        //    if (result == "success")
        //        return Ok("success");
        //    else
        //        return BadRequest(result);



        //}
    }
}
