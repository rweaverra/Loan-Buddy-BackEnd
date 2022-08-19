using Loan_Buddy_Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace Loan_Buddy_Api.Services.LoanAgreementService
{
    public interface ILoanAgreementService
    {
       
        Task<ServiceResponse<Dictionary<string, object>>> GetLoanAgreements(int userId);
        Task<ServiceResponse<LoanAgreement>> GetAllLoanInfoWithLoanId(int loanId);
        //Task<ActionResult<object>> LoanAgreementCreate([FromBody] string value);

    }
}
