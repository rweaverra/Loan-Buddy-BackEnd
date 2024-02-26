using Loan_Buddy_Api.Models;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MimeKit;
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
        Task SaveBase64StringAsPdfFile(int id, string pdfBase64String);
        Task UpdateLoanToIncludeSignedBy(LoanAgreement loanAgreement, string typeOfLoan);
        string EmailCompletedPdfToBothUsers(User firstSigner, User secondSigner, int loanId);
        Task<ServiceResponse<Dictionary<string, object>>> SubmitPreviousTransactionsCSV(IFormFile file, string loanId);



    }
}
