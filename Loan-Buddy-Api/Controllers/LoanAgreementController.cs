using Loan_Buddy_Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

       //Could really optimize the search, could also look into the foreign key stuff.
        [HttpGet("getAllLoanInfo/{loanId}/{userId}")]
        public async Task<ActionResult<Dictionary<string, object>>> GetAllLoanInfoWithLoanId(int loanId, int userId)
        {
            
            var results = new Dictionary<string, object>();


            LoanAgreement? loanAgreement = await _db.LoanAgreements.Where(r => r.LoanAgreementId == loanId).SingleOrDefaultAsync();

            if (loanAgreement == null)
                return BadRequest("no Loan Agreement with that Id");
            
            int? lenderId = loanAgreement.LenderId;
            int? borrowerId = loanAgreement.BorrowerId;

            dynamic? loanCoSigner = null;
            if(userId == lenderId)
            {
                loanCoSigner = await _db.Users.Where(u => u.UserId == borrowerId).SingleOrDefaultAsync();
            }
            else if (userId == borrowerId)
            {
                loanCoSigner = await _db.Users.Where(u => u.UserId == lenderId).SingleOrDefaultAsync();
            }

            var transactions = await _db.Transactions.Where(r => r.LoanAgreementId == loanId).ToListAsync();
            var userInfo = await _db.Users.SingleAsync(r => r.UserId == userId);



            results.Add("loanAgreement", loanAgreement);
            results.Add("transactions", transactions);
            results.Add("userInfo", userInfo);

            if(loanCoSigner is not null)
              results.Add("loanCoSigner", loanCoSigner);
               
                return Ok(results);     
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
