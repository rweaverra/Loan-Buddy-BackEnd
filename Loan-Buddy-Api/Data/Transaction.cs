using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Loan_Buddy_Api.Data
{
    public enum TransactionType
    {
        Cash,
        Check,
        BankWire,
        ThirdPartyApp
    }
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        public int Amount { get; set; }

        //Change payment type to foreign key
        [MaxLength(200)]
        public string TransactionType { get; set; }

        public DateTime Date { get; set; }

        public int RemainingTotal { get; set; }

        public bool ProofOfPayment { get; set; }

        //Is the foreign Key, system looks for its name compared to its referenced entities and sees if it
        //should be a foreign key. I think.
        public int LoanAgreementId { get; set; }

        //Reference property. It doesn't add any columns it just references this table
        //public LoanAgreement LoanAgreement { get; set; }


    }
}
