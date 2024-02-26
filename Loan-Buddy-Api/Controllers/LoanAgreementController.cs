
using Loan_Buddy_Api.Models;
using Loan_Buddy_Api.Services.LoanAgreementService;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit.Text;
using MimeKit;
using System.IO;
using System.Text.Json.Nodes;
using MailKit.Net.Smtp;
using Org.BouncyCastle.Crypto.Agreement;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using static System.Net.WebRequestMethods;

namespace Loan_Buddy_Api.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class LoanAgreementController : ControllerBase
    {
        private readonly ILoanAgreementService _loanAgreementService;
        private readonly IConfiguration _configuration;

        public LoanAgreementController(ILoanAgreementService loanAgreementService, IConfiguration configuration)
        {
            _loanAgreementService = loanAgreementService;
            _configuration = configuration;
        }

        [HttpGet("/loanAgreementsGet/{userId}")]
        public async Task<ServiceResponse<Dictionary<string, object>>> GetLoanAgreements(int userId)
        {
            return await _loanAgreementService.GetLoanAgreements(userId);
        }

        [HttpGet("getAllLoanInfo/{loanId}")]
        public async Task<ServiceResponse<Dictionary<string, object>>> GetAllLoanInfoWithLoanId(int loanId)
        {

            return await _loanAgreementService.GetAllLoanInfoWithLoanId(loanId);
        }

        [HttpPost("SubmitSecondSigLoanAgreement")]
        public async Task<ActionResult<ServiceResponse<object>>> SubmitSecondSigLoanAgreement(JsonObject data)
        {
            return Ok(await _loanAgreementService.SubmitSecondSigLoanAgreement(data));
        }

          [HttpPost("SubmitNewLoanAgreement")]
        public async Task<ActionResult<ServiceResponse<object>>> SubmitNewLoanAgreement(JsonObject data)
   
        {              
               return  Ok( await _loanAgreementService.SubmitNewLoanAgreement(data));
     
        }

        [HttpPost("SubmitPreviousTransactionsCSV")]
        [Consumes("multipart/form-data")]

        public async Task<ActionResult<ServiceResponse<object>>> SubmitPreviousTransactionsCSV(IFormFile file, string loanId)

        {
                return Ok(await _loanAgreementService.SubmitPreviousTransactionsCSV(file, loanId));
            
        }

    }
}
