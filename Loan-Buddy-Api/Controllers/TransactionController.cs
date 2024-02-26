using Loan_Buddy_Api.Models;
using Loan_Buddy_Api.Services.TransactionService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Loan_Buddy_Api.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("{loanId}")]
        public async Task<ServiceResponse<IEnumerable<Transaction>>> GetLoanTransactions(int loanId)

        {
            return await _transactionService.GetLoanTransactions(loanId);    
        }

        [HttpPost("PostTransaction")]
        public async Task <ServiceResponse<Transaction>> PostTransaction([FromBody] Transaction transaction)
        {
            return await _transactionService.PostTransaction(transaction);       
        }
    }
}
