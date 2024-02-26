using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Loan_Buddy_Api.Models
{

    //should probably be added as db table
    public enum TransactionType
    {
        Cash,
        Check,
        BankWire,
        ThirdPartyApp,
        Other
    }

    //should probably be added as db table
    public enum ThirdPartyApp
    {
        Venmo,
        Zelle,
        PayPal,
        Other
    }
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        public decimal? Amount { get; set; }

        //Change payment type to foreign key
        [MaxLength(200)]
        public string? TransactionType { get; set; }

        public string? ThirdPartyApp { get; set; }

        public DateTime? Date { get; set; }

        public decimal? RemainingTotal { get; set; }

        public bool? RequiresProofOfPayment { get; set; } = false;

        //the image will be stored as a file with the id as the file name. 
        public int? ProofOfPaymentId { get; set; }

        public int LoanAgreementId { get; set; }



    }
}
