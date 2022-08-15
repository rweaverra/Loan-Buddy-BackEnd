using Loan_Buddy_Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace Loan_Buddy_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoanAgreementController : ControllerBase
    {
        private AppDBContext db = new AppDBContext();

        [HttpGet("GetLoanAgreements")]
        public async Task<IEnumerable<LoanAgreement>> GetLoanAgreements()
        {
            return db.LoanAgreements.ToList();
        }

    }
}
