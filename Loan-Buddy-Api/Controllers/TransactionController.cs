using Loan_Buddy_Api.Data;
using Loan_Buddy_Api.Services;
using Loan_Buddy_Api.Services.TransactionService;
using Microsoft.AspNetCore.Mvc;

namespace Loan_Buddy_Api.Controllers
{
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

        [HttpPost("postTransaction")]
        public async Task <ServiceResponse<Transaction>> PostTransaction([FromBody] Transaction transaction)
        {
            return await _transactionService.PostTransaction(transaction);       
        }
    }
}
