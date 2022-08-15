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

        [MaxLength(50)]
        public string DateCreated { get; set; } = string.Empty;
        public int MonthlyPaymentAmount { get; set; }
        public int RemainingTotal { get; set; }

    }
}
