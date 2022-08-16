using Loan_Buddy_Api.Data;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace Loan_Buddy_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoanAgreementController : ControllerBase
    {
        private AppDBContext _db = new AppDBContext();

        [HttpGet("{userId}")]
        public async Task<Dictionary<string, object>> GetLoanAgreements(int userId)
        {
            //grab all loan agreements based on user id

            var lendingAgreements = await _db.LoanAgreements.Where(r => r.LenderId == userId).ToListAsync();
            var borrowingAgreements = await _db.LoanAgreements.Where(r => r.BorrowerId == userId).ToListAsync();

            var results = new Dictionary<string, object>()
            {
                { "lendingAgreements", lendingAgreements },
                { "borrowingAgreements", borrowingAgreements }
            };

            return results;
        }

        //get user info, specific loan info and transactions
        [HttpGet()]
        public async Task<ActionResult<Dictionary<string, object>>> GetLoanAgreementById(int loanId)
        {
            try
            {
            var results = new Dictionary<string, object>();
                //inner join all of it, or three separate calls?
            return Ok(results);

            }
            catch(Exception ex)
            {
                return BadRequest("unable to grab Loan Agreement based on User Id" + ex);
            }

            //grab user info
            //grab loan agreement info
            //grab transactions info

        }

        [HttpPost("{loanAgreement}")]
        public async Task<ActionResult<LoanAgreement>> AddLoanAgreement(LoanAgreement loanAgreement)
        {
            try
            {
                loanAgreement.DateCreated = DateTime.Now;
                _db.LoanAgreements.Add(loanAgreement);
                await _db.SaveChangesAsync();

                return Ok(loanAgreement);
            }
            catch(Exception err)
            {
                return BadRequest("loan agreement was not added" + err);
            }

        }

    }
}
