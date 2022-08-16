using System.ComponentModel.DataAnnotations;

namespace Loan_Buddy_Api.Data
{

    public class LoanAgreement
    {
        [Key]
        public int LoanAgreementId { get; set; }

        [Required]
        public int LenderId { get; set; } 

        [Required]
        public int BorrowerId { get; set; }

        public int OriginalAmount { get; set; }
        public DateTime DateCreated { get; set; }
        public int MonthlyPaymentAmount { get; set; }
        public int RemainingTotal { get; set; }
        public bool SignedByBorrower { get; set; } = false;
        public bool SignedByLender { get; set; } = false;

    }
}
