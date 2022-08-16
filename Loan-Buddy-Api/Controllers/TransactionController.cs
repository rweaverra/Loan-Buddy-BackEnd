using Loan_Buddy_Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace Loan_Buddy_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private AppDBContext db = new AppDBContext();
      
        [HttpGet()]
        public async Task <IEnumerable<Transaction>> GetLoanTransactions(int loanId)

        {
            var query = db.Transactions.Where(r => r.LoanAgreementId == loanId);

            return query;      
        }

        [HttpPost()]
        public async Task <Transaction> PostTransaction(Transaction transaction)
        {
            transaction.Date = DateTime.Now;

            //calculate remaining total by grabbing the loan agreement
            var loanAmountRemaning = db.LoanAgreements.Where(r => r.LoanAgreementId == transaction.LoanAgreementId)
                .Select(c => c.RemainingTotal)
                .FirstOrDefault();

           loanAmountRemaning = loanAmountRemaning - transaction.Amount;

           var loanAgreement = db.LoanAgreements.Find(transaction.LoanAgreementId);
            loanAgreement.RemainingTotal = loanAmountRemaning;

            transaction.RemainingTotal = loanAmountRemaning;

            db.Transactions.Add(transaction);
            db.SaveChanges();

            return transaction;
        }
    }
}
