using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loan_Buddy_Api.Data
{

    public class LoanAgreement
    {
        public int LoanAgreementId { get; set; }
        public int OriginalAmount { get; set; }
        public DateTime DateCreated { get; set; }
        public int MonthlyPaymentAmount { get; set; }
        public int RemainingTotal { get; set; }
        public bool SignedByBorrower { get; set; } = false;
        public bool SignedByLender { get; set; } = false;

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
