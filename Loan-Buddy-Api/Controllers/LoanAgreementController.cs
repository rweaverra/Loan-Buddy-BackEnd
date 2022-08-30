
using Loan_Buddy_Api.Models;
using Loan_Buddy_Api.Services.LoanAgreementService;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit.Text;
using MimeKit;
using PuppeteerSharp; //remove
using System.IO;
using System.Text.Json.Nodes;
using MailKit.Net.Smtp;
using Org.BouncyCastle.Crypto.Agreement;
using Microsoft.Extensions.Configuration;

namespace Loan_Buddy_Api.Controllers
{
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


        [HttpGet("/createPDF")]
        public async Task<ServiceResponse<object>> CreatePDF()
        {
            var serviceResponse = new ServiceResponse<object>();
            serviceResponse.Data = "Creating PDF";


            var html = System.IO.File.ReadAllText("./Controllers/invoice.html");
            string path = "./Controllers/invoice1.pdf";

            var pdfOptions = new PuppeteerSharp.PdfOptions();

            using (var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true,
                //I think it is impossible to have a chrome executable on my production site, unless I use special service.
                ExecutablePath = "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe"
            }))
            {
                using (var page = await browser.NewPageAsync())
                {
                    await page.SetContentAsync(html);
                    await page.PdfAsync(path, pdfOptions);
                }
            }

            return serviceResponse;
        }


        //***MOVE TO USER CONTROLLER

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

        [HttpGet("sendSignedPDF")]
        public async Task<object> SendSignedPDF()
        {
            // create email message
            //var email = new MimeMessage();
            //email.From.Add(MailboxAddress.Parse("rweaverra@gmail.com"));
            //email.To.Add(MailboxAddress.Parse("rweaverra@gmail.com"));
            //email.Subject = "Test Email Subject";
            //email.Body = new TextPart(TextFormat.Plain) { Text = "Example Plain Text Message Body" };

       

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("loanBuddy", "loanbuddyemail@gmail.com"));
            message.To.Add(new MailboxAddress("Alice", "rweaverra@gmail.com"));
            message.Subject = "How you doin?";

            var builder = new BodyBuilder();

            // Set the plain-text version of the message text
            builder.TextBody = @"Hey Alice,

                    What are you up to this weekend? Monica is throwing one of her parties on
                    Saturday and I was hoping you could make it.

                    Will you be my +1?

                    -- Joey
                    ";

            // We may also want to attach a calendar event for Monica's party...
            builder.Attachments.Add(@"./Data/LoanAgreementPDFs/19.pdf");

            // Now we just need to set the message body and we're done
            message.Body = builder.ToMessageBody();


            // send email
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("loanbuddyemail@gmail.com", "mawuivdpasfsopzg");
            smtp.Send(message);
            smtp.Disconnect(true);




            return "email sent";
        }

        //SubmitSecondSigLoanAgreement
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

        

    }
}
