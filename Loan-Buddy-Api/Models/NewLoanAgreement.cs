using Loan_Buddy_Api.Data;

namespace Loan_Buddy_Api.Models
{
    public class NewLoanAgreement
    {
        public string PdfBase64String { get; set; } = string.Empty;
        public string TypeOfLoan { get; set; } = string.Empty;
        public User? OtherPartyInfo { get; set; }
        public LoanAgreement? LoanDetails { get; set; }
        public User? UserInfo { get; set; }

    }

}
