using Loan_Buddy_Api.Models;

namespace Loan_Buddy_Api.Services.TransactionService
{
    public interface ITransactionService
    {
        public Task<ServiceResponse<IEnumerable<Transaction>>> GetLoanTransactions(int loanId);
        public Task<ServiceResponse<Transaction>> PostTransaction(Transaction transaction);
    }
}
