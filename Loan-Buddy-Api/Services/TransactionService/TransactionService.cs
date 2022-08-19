using Loan_Buddy_Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Loan_Buddy_Api.Services.TransactionService
{
    public class TransactionService : ITransactionService
    {
        private readonly AppDBContext _db = new AppDBContext();
        public async Task<ServiceResponse<IEnumerable<Transaction>>> GetLoanTransactions(int loanId)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<Transaction>>();
            var transactions = await _db.Transactions.Where(r => r.LoanAgreementId == loanId).ToListAsync();

            serviceResponse.Data = transactions;

            return serviceResponse;
        }

        public async Task<ServiceResponse<Transaction>> PostTransaction(Transaction transaction)
        {

            var serviceResponse = new ServiceResponse<Transaction>();
            transaction.Date = DateTime.Now;

            //calculate remaining total by grabbing the loan agreement
            var loanAmountRemaning = await _db.LoanAgreements
                .Where(r => r.LoanAgreementId == transaction.LoanAgreementId)
                .Select(c => c.RemainingTotal)
                .FirstOrDefaultAsync();

            loanAmountRemaning = loanAmountRemaning - transaction.Amount;

            var loanAgreement = await _db.LoanAgreements.FindAsync(transaction.LoanAgreementId);
            loanAgreement.RemainingTotal = loanAmountRemaning;

            transaction.RemainingTotal = loanAmountRemaning;

            _db.Transactions.Add(transaction);
            await _db.SaveChangesAsync();

            serviceResponse.Data = transaction;

            return serviceResponse;
        }
    }
}
