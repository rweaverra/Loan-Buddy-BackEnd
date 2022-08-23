using Loan_Buddy_Api.Data;

namespace Loan_Buddy_Api.Dtos
{
    public class ReturnedLoanAgreement
    {
        public string PdfBase64String { get; set; } = string.Empty;
        public LoanAgreement? LoanAgreement { get; set; }
        public User? UserInfo { get; set; }

    }
}
