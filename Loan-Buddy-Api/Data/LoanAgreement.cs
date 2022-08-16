using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loan_Buddy_Api.Data
{

    public class LoanAgreement
    {
        [Key] //may have to remove this???
        public int LoanAgreementId { get; set; }

        //[Required]
        //public int LenderId { get; set; } 

        //[Required]
        //public int BorrowerId { get; set; }

        public int OriginalAmount { get; set; }
        public DateTime DateCreated { get; set; }
        public int MonthlyPaymentAmount { get; set; }
        public int RemainingTotal { get; set; }
        public bool SignedByBorrower { get; set; } = false;
        public bool SignedByLender { get; set; } = false;

        //public int LenderId { get; set; }
        //[ForeignKey("LenderId")]
        //public User LenderId { get; set; }

        //public int BorrowerId { get; set; }
        //[ForeignKey("BorrowerId")]
        //public User User { get; set; }

        public int? LenderId { get; set; }
        [ForeignKey("LenderId")]
        public User Lender { get; set; }

        public int? BorrowerId { get; set; }
        [ForeignKey("BorrowerId")]
        public virtual User Borrower { get; set; }

        //navigation collection property
        public ICollection<Transaction> Transactions { get; set; }

    }
}
