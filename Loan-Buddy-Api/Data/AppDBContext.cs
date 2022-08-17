﻿//using System.Data.Entity;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection.Metadata;
using System.Xml.Linq;


namespace Loan_Buddy_Api.Data
{


    public class AppDBContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer();
            optionsBuilder.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = LoanBuddyDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False"
);
            //@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = LoanBuddyDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False"
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Name = "Bill", Email = "bill@gmail.com", Password = "password" },
                new User() { UserId = 2, Name = "Janet", Email = "Janet@gmail.com", Password = "password" });

            modelBuilder.Entity<LoanAgreement>().HasData(
                new LoanAgreement()
                {
                    LoanAgreementId = 1,
                    BorrowerId = 1,
                    DateCreated = DateTime.Now,
                    LenderId = 2,
                    MonthlyPaymentAmount = 240,
                    OriginalAmount = 24242,
                    RemainingTotal = 2424
                }); ;

            modelBuilder.Entity<Transaction>().HasData(
                new Transaction()
                {
                    TransactionId = 1,
                    Amount = 55,
                    Date = System.DateTime.Now,
                    LoanAgreementId = 1,
                    TransactionType = TransactionType.Cash.ToString(),
                    ProofOfPayment = false,
                    RemainingTotal = 2324
                });

        }

        public DbSet<User> Users { get; set; }
        public DbSet<LoanAgreement> LoanAgreements { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }





}
