using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loan_Buddy_Api.Models
{
    public enum LoanCreator
    {
        Lender,
        Borrower
    }
    public class LoanAgreement
    {
        public int LoanAgreementId { get; set; }
        public decimal? OriginalAmount { get; set; }
        public DateTime? DateCreated { get; set; }
        public decimal? MonthlyPaymentAmount { get; set; }
        public decimal? RemainingTotal { get; set; }
        public bool RequiresSignatures { get; set; } = false;
        public bool SignedByBorrower { get; set; } = false;
        public bool SignedByLender { get; set; } = false;

        public string LoanCreator { get; set; } = string.Empty;
        
        //navigation collection property
        public ICollection<Transaction> Transactions { get; set; }

        //foreign keys
        public int? BorrowerId { get; set; }
        [ForeignKey("BorrowerId")]
        public User BorrowerDetail { get; set; }

        public int? LenderId { get; set; }
        [ForeignKey("LenderId")]
        public User LenderDetail { get; set; }



    }
}
