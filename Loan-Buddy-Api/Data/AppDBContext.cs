using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;

namespace Loan_Buddy_Api.Data
{


    public class AppDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<LoanAgreement> LoanAgreements { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }





}
