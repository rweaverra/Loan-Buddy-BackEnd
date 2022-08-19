using Loan_Buddy_Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Loan_Buddy_Api.Services.LoanAgreementService
{
    public class LoanAgreementService : ILoanAgreementService
    {
        private AppDBContext _db = new AppDBContext();
        public async Task<ServiceResponse<LoanAgreement>> GetAllLoanInfoWithLoanId(int loanId)
        {
            var serviceResponse = new ServiceResponse<LoanAgreement>();

            var loanAgreement = await _db.LoanAgreements
                .Include(l => l.Transactions)
                .Include(l => l.BorrowerDetail)
                .Include(l => l.LenderDetail)
                .Where(l => l.LoanAgreementId == loanId)
                .SingleOrDefaultAsync();

            //if (loanAgreement is null)
            //    return BadRequest("No loan Agreement with that Id");
            serviceResponse.Data = loanAgreement;

            return serviceResponse;
        }

        public async Task<ServiceResponse<Dictionary<string, object>>> GetLoanAgreements(int userId)
        {
            var serviceResponse = new ServiceResponse<Dictionary<string, object>>();
            var results = new Dictionary<string, object>();

            var user = await _db.Users.SingleOrDefaultAsync(r => r.UserId == userId);
            var loanAgreements = await _db.LoanAgreements
                .Include(l => l.BorrowerDetail)
                .Include(l => l.LenderDetail)
                .Where(r => r.LenderId == userId || r.BorrowerId == userId).ToListAsync();

            //if (user == null || loanAgreements == null)
            //    return "error retreiving loan agreements";

            results.Add("userInfo", user);
            results.Add("loanAgreements", loanAgreements);

            serviceResponse.Data = results;

            return serviceResponse;
        }
    }
}
