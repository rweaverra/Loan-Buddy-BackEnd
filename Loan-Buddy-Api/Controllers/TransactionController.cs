using Loan_Buddy_Api.Data;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace Loan_Buddy_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly AppDBContext _db = new AppDBContext();



        [HttpGet("{loanId}")]
        public async Task <IEnumerable<Transaction>> GetLoanTransactions(int loanId)

        {
            var query = await _db.Transactions.Where(r => r.LoanAgreementId == loanId).ToListAsync();

            return query;      
        }

        [HttpPost("{transaction}")]
        public async Task <Transaction> PostTransaction(Transaction transaction)
        {
            transaction.Date = DateTime.Now;

            //calculate remaining total by grabbing the loan agreement
            var loanAmountRemaning = _db.LoanAgreements.Where(r => r.LoanAgreementId == transaction.LoanAgreementId)
                .Select(c => c.RemainingTotal)
                .FirstOrDefault();

           loanAmountRemaning = loanAmountRemaning - transaction.Amount;

           var loanAgreement = _db.LoanAgreements.Find(transaction.LoanAgreementId);
            loanAgreement.RemainingTotal = loanAmountRemaning;

            transaction.RemainingTotal = loanAmountRemaning;

            _db.Transactions.Add(transaction);
            await _db.SaveChangesAsync();

            return transaction;
        }
    }
}
