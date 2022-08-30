using Loan_Buddy_Api.Models;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Loan_Buddy_Api.Services.LoanAgreementService
{
    public interface ILoanAgreementService
    {
       
        Task<ServiceResponse<Dictionary<string, object>>> GetLoanAgreements(int userId);
        Task<ServiceResponse<Dictionary<string, object>>> GetAllLoanInfoWithLoanId(int loanId);
        Task<ServiceResponse<object>> SubmitNewLoanAgreement(JsonObject data);
        Task<ServiceResponse<object>> SubmitSecondSigLoanAgreement(JsonObject data);
        string GetPdf(int loanId);
        Task saveBase64StringAsPdfFile(int id, string pdfBase64String);
        Task updateLoanToIncludeSignedBy(LoanAgreement loanAgreement, string typeOfLoan);
        string emailCompletedPdfToBothUsers(User firstSigner, User secondSigner, int loanId);
        

    }
}
