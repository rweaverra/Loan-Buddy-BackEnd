using Loan_Buddy_Api.Data;
using Loan_Buddy_Api.Services;
using Loan_Buddy_Api.Services.LoanAgreementService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using PuppeteerSharp;
using System.IO;

namespace Loan_Buddy_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoanAgreementController : ControllerBase
    {
        private readonly ILoanAgreementService _loanAgreementService;

        public LoanAgreementController(ILoanAgreementService loanAgreementService)
        {
           _loanAgreementService = loanAgreementService;
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

        [HttpPost("SubmitFinishedLoanAgreement")]
        public async Task<ActionResult<ServiceResponse<object>>> SubmitFinishedLoanAgreement([FromBody] object data)
   
        {
            try
            {
                var serviceResponse = new ServiceResponse<object>();

                
                /*need to make a class with LoanAgreement, string, User
                 * then use this class to map all the returning data. 
                 *      how to map if not providing an id?(look at other project)
                 * add loan agreements to database
                 * add new user to User table and create a temp password
                 * add pdf file to LoanAgreementPDFs
                 * send an email with the PDF
                */
                JObject json = JObject.Parse(data.ToString());

                //add agreement to database and get the new aggreement id
                //save the pdf as the agreement Id





                //pdf saving
                if (json["data"].ToString() is not null && json["data"]["pdfBase64String"] is not null)
                {
                    string pdfString = json["data"]["pdfBase64String"].ToString();

                    //have to remove extra characters "data:application/pdf;base64, which were added when the pdf was saved on front end
                    //string result = pdfString.Remove(0, 29);
                    //result = result.Remove(result.Length - 1);                                  
                    byte[] sPDFDecoded = Convert.FromBase64String(pdfString);
                    System.IO.File.WriteAllBytes($"./Data/LoanAgreementPDFs/signedPDF.pdf", sPDFDecoded);


                    serviceResponse.Data = pdfString;
                    return Ok(serviceResponse);

                }




                return Ok(json);


                //System.IO.File.WriteAllBytes("./submitedpdf", GetBytes(value["formData"]));


            }
            catch (Exception err)
            {
                return BadRequest("loan agreement was not added" + err);
            }

        }

        

    }
}
