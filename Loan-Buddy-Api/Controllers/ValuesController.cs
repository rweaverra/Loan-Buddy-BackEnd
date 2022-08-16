using Microsoft.AspNetCore.Mvc;
using Loan_Buddy_Api.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Loan_Buddy_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private AppDBContext _db = new AppDBContext();
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //[HttpGet("GetLoanAgreements")]
        //public async Task<IEnumerable<LoanAgreement>> GetLoanAgreements()
        //{
        //    return db.LoanAgreements.ToList();
        //}

        //[HttpGet("GetUsers")]
        //public async Task<IEnumerable<User>> GetUsers()

        //{
        //    return db.Users.ToList();

           
        //}  
        //// GET api/<ValuesController>/5
        //[HttpGet("Users")]
        //public string GetUser()
        //{ 
        //    return "Joe Turner, turn into JSON object eventually";
        //}

    }
}
