using Loan_Buddy_Api.Data;
using Loan_Buddy_Api.Services;
using Loan_Buddy_Api.Services.LoanAgreementService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Loan_Buddy_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoanAgreementController : ControllerBase
    {
        private AppDBContext _db = new AppDBContext();
        private readonly ILoanAgreementService _loanAgreementService;

        public LoanAgreementController(ILoanAgreementService loanAgreementService)
        {
           _loanAgreementService = loanAgreementService;
        }


        //***MOVE TO USER CONTROLLER

        [HttpGet("/loanAgreementsGet/{userId}")]
        public async Task<ServiceResponse<Dictionary<string, object>>> GetLoanAgreements(int userId)
        {               
            return await _loanAgreementService.GetLoanAgreements(userId);
        }

        [HttpGet("getAllLoanInfo/{loanId}")]
        public async Task<ServiceResponse<LoanAgreement>> GetAllLoanInfoWithLoanId(int loanId)
        {
  
            return await _loanAgreementService.GetAllLoanInfoWithLoanId(loanId);
        }
  
        [HttpPost("LoanAgreementCreate")]
        public async Task<ActionResult<object>> LoanAgreementCreate([FromBody] string value)
            //dont forget to move to IAUTHSERVICE
        {
            try
            {
               

                return Ok(value);
            }
            catch(Exception err)
            {
                return BadRequest("loan agreement was not added" + err);
            }

        }

    }
}
