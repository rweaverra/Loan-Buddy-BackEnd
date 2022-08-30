using Loan_Buddy_Api.Data;
using Loan_Buddy_Api.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using MimeKit.Text;
using System;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Text.Json.Nodes;


namespace Loan_Buddy_Api.Services.LoanAgreementService
{
    public class LoanAgreementService : ILoanAgreementService
    {
        private readonly AppDBContext _db;
        private readonly IConfiguration _configuration;

        public LoanAgreementService(AppDBContext context, IConfiguration configuration)
        {
            _db = context;
            _configuration = configuration;
        }
        public async Task<ServiceResponse<Dictionary<string, object>>> GetAllLoanInfoWithLoanId(int loanId)
        {
            var serviceResponse = new ServiceResponse<Dictionary<string, object>>();
            var result = new Dictionary<string, object>();

            try
            {
              var loanAgreement = await _db.LoanAgreements
                .Include(l => l.Transactions)
                .Include(l => l.BorrowerDetail)
                .Include(l => l.LenderDetail)
                .Where(l => l.LoanAgreementId == loanId)
                .SingleOrDefaultAsync();


                string pdfBase64String = GetPdf(loanId);
                //if (loanAgreement is null)
                //    return BadRequest("No loan Agreement with that Id");
                result.Add("pdfBase64String", pdfBase64String);
                result.Add("loanAgreement", loanAgreement);
            
                serviceResponse.Data = result;

            } 
            catch(Exception err)
            {
                result.Add("error", err);
                serviceResponse.Data = result;
                serviceResponse.Success = false;
            }

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

        private string emailOtherUserLink(User otherUser, User agreementCreator)
        {
            try
            {
        
                var site = _configuration.GetSection("EmailSettings").Get<EmailSettings>();
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(agreementCreator.Email)); //eventually change
                email.To.Add(MailboxAddress.Parse(otherUser.Email)); //eventually change
                email.Subject = "Test Email Subject";
                email.Body = new TextPart(TextFormat.Plain) { Text = @$"Hi {otherUser.Name},

                        Please use this link to see view the loan agreement from {agreementCreator.Name}.
                        if you agree to the terms, sign the pdf from the link to finalize the loan agreement
                        Link: {site.Url}user-info/{otherUser.UserId}
                            " };


                // send email
                using var smtp = new SmtpClient();
                smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate(site.Email, site.Password);
                smtp.Send(email);
                smtp.Disconnect(true);

                return "email sent";
            }
            catch(Exception err)
            {
                return err.Message;
            }
        }

        public async Task<ServiceResponse<object>> SubmitNewLoanAgreement(JsonObject data)
        {
            var serviceResponse = new ServiceResponse<object>();
            var options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = true;      
            
            var results = JsonSerializer.Deserialize<NewLoanAgreement>(data, options);

            LoanAgreement loanAgreement = results.LoanDetails;
            var userInfo = results.UserInfo;

            //add new user
            User newUser = results.OtherPartyInfo;
            newUser.Password = "123"; //temp password
            _db.Users.Add(newUser);
            await _db.SaveChangesAsync();

            if (results.TypeOfLoan == "borrow") 
            { 
                loanAgreement.BorrowerId = userInfo.UserId;
                loanAgreement.LenderId = newUser.UserId;
            }
            if (results.TypeOfLoan == "lend") 
            { 
                loanAgreement.LenderId = userInfo.UserId;
                loanAgreement.BorrowerId = newUser.UserId;
            }

            _db.LoanAgreements.Add(loanAgreement);
             await _db.SaveChangesAsync();

            //pdf saving
            string id = loanAgreement.LoanAgreementId.ToString();
            string pdfString = results.PdfBase64String;
            byte[] sPDFDecoded = Convert.FromBase64String(pdfString);
            System.IO.File.WriteAllBytes($"./Data/LoanAgreementPDFs/{id}.pdf", sPDFDecoded);

            // send an email to user's email to log in.
            emailOtherUserLink(newUser, userInfo);

            serviceResponse.Data = newUser;

            return serviceResponse;
        }

        public string GetPdf(int loanId)
        {
          
            try
            {

            Byte[] bytes =  File.ReadAllBytes($"./Data/LoanAgreementPDFs/{loanId}.pdf");
            String file = Convert.ToBase64String(bytes);

                return file;
            }
            catch
            {
                return $"no signed loan agreement with loan id: {loanId}";
            }    
        }

        public async Task<ServiceResponse<object>> SubmitSecondSigLoanAgreement(JsonObject data)
        {
            var serviceResponse = new ServiceResponse<object>();

            try
            {
                var options = new JsonSerializerOptions();
                options.PropertyNameCaseInsensitive = true;

                var results = JsonSerializer.Deserialize<NewLoanAgreement>(data, options);
 

                var loanAgreement = results.LoanDetails;
                var pdfBase64String = results.PdfBase64String;
                var typeOfLoan = results.TypeOfLoan;
                

                if(loanAgreement is null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Success = false;
                    serviceResponse.Message = "No matching loan agreement";
                    return serviceResponse;
                }

                await updateLoanToIncludeSignedBy(loanAgreement, typeOfLoan);
              
                await saveBase64StringAsPdfFile(loanAgreement.LoanAgreementId, pdfBase64String);

                var wasEmailed = emailCompletedPdfToBothUsers(loanAgreement.BorrowerDetail, loanAgreement.LenderDetail, loanAgreement.LoanAgreementId);

                //get both users emails

                serviceResponse.Data = wasEmailed;
            }
            catch(Exception err)
            {
                serviceResponse.Data = err;
            }

            return serviceResponse;
        }

        public async Task saveBase64StringAsPdfFile(int id, string pdfBase64String)
        {
            
            byte[] sPDFDecoded = Convert.FromBase64String(pdfBase64String);
            await System.IO.File.WriteAllBytesAsync($"./Data/LoanAgreementPDFs/{id}.pdf", sPDFDecoded);
        }

        public async Task updateLoanToIncludeSignedBy(LoanAgreement loanAgreement, string typeOfLoan)
        {
            var updatedLoan = await _db.LoanAgreements
                    .Where(l => l.LoanAgreementId == loanAgreement.LoanAgreementId)
                    .SingleOrDefaultAsync();

            if (typeOfLoan == "borrow") updatedLoan.SignedByBorrower = loanAgreement.SignedByBorrower;
            else if (typeOfLoan == "lend") updatedLoan.SignedByLender = loanAgreement.SignedByLender;

            await _db.SaveChangesAsync();
        }

        public string emailCompletedPdfToBothUsers(User firstSigner, User secondSigner, int loanId)
        {
            try
            {

                var site = _configuration.GetSection("EmailSettings").Get<EmailSettings>();
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("loanbuddyemail@gmail.com")); //eventually change
                email.To.Add(MailboxAddress.Parse(firstSigner.Email));
                email.Cc.Add(MailboxAddress.Parse(secondSigner.Email));//eventually change
                email.Subject = "Contract Complete";


                var builder = new BodyBuilder();

                builder.TextBody = @$"
                           Both users have signed the aggreement. The signed aggreement is attached.
                           To record payments, login to {site.Url} and select 'Make a payment'.
                            ";

                builder.Attachments.Add($"./Data/LoanAgreementPDFs/{loanId}.pdf");

                email.Body = builder.ToMessageBody();


                // send email
                using var smtp = new SmtpClient();
                smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate(site.Email, site.Password);
                smtp.Send(email);
                smtp.Disconnect(true);

                return "email sent";
            }
            catch (Exception err)
            {
                return err.Message;
            }
        }
    }
}
