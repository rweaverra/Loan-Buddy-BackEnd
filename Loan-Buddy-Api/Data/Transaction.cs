using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        //Guess I don't exactly need Foreign keys for now
        public int LoanAgreementId { get; set; }

        public int Amount { get; set; }

        //Change payment type to foreign key
        [MaxLength(200)]
        public string TransactionType { get; set; }

        public DateTime Date { get; set; }

        public int RemainingTotal { get; set; }

        public bool ProofOfPayment { get; set; }
        
       
    }
}
