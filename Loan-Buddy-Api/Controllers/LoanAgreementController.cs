using Loan_Buddy_Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace Loan_Buddy_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoanAgreementController : ControllerBase
    {
        private AppDBContext db = new AppDBContext();

        [HttpGet()]
        public async Task<Dictionary<string, object>> GetLoanAgreement(int userId)
        {
            //grab all loan agreements based on user id

            var lendingAgreements = db.LoanAgreements.Where(r => r.LenderId == userId);
            var borrowingAgreements = db.LoanAgreements.Where(r => r.BorrowerId == userId);

            var results = new Dictionary<string, object>()
            {
                { "lendingAgreements", lendingAgreements },
                { "borrowingAgreements", borrowingAgreements }
            };

            return results;
        }

        [HttpPost()]
        public async Task<LoanAgreement> AddLoanAgreement(LoanAgreement loanAgreement)
        {
            //insert info into db

            loanAgreement.DateCreated = DateTime.Now;

            db.LoanAgreements.Add(loanAgreement);


            return loanAgreement;
        }

    }
}
