﻿// <auto-generated />
using System;
using Loan_Buddy_Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Loan_Buddy_Api.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20220831235938_transactionupdate6")]
    partial class transactionupdate6
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Loan_Buddy_Api.Models.LoanAgreement", b =>
                {
                    b.Property<int>("LoanAgreementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoanAgreementId"), 1L, 1);

                    b.Property<int?>("BorrowerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LenderId")
                        .HasColumnType("int");

                    b.Property<decimal?>("MonthlyPaymentAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("OriginalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("RemainingTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("RequiresSignatures")
                        .HasColumnType("bit");

                    b.Property<bool>("SignedByBorrower")
                        .HasColumnType("bit");

                    b.Property<bool>("SignedByLender")
                        .HasColumnType("bit");

                    b.HasKey("LoanAgreementId");

                    b.HasIndex("BorrowerId");

                    b.HasIndex("LenderId");

                    b.ToTable("LoanAgreements");

                    b.HasData(
                        new
                        {
                            LoanAgreementId = 1,
                            BorrowerId = 1,
                            DateCreated = new DateTime(2022, 8, 31, 17, 59, 38, 285, DateTimeKind.Local).AddTicks(6271),
                            LenderId = 2,
                            MonthlyPaymentAmount = 240m,
                            OriginalAmount = 24242m,
                            RemainingTotal = 2424m,
                            RequiresSignatures = false,
                            SignedByBorrower = false,
                            SignedByLender = false
                        });
                });

            modelBuilder.Entity("Loan_Buddy_Api.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionId"), 1L, 1);

                    b.Property<int?>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("LoanAgreementId")
                        .HasColumnType("int");

                    b.Property<int?>("ProofOfPaymentId")
                        .HasColumnType("int");

                    b.Property<decimal?>("RemainingTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool?>("RequiresProofOfPayment")
                        .HasColumnType("bit");

                    b.Property<string>("ThirdPartyApp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionType")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("TransactionId");

                    b.HasIndex("LoanAgreementId");

                    b.ToTable("Transactions");

                    b.HasData(
                        new
                        {
                            TransactionId = 1,
                            Amount = 55,
                            Date = new DateTime(2022, 8, 31, 17, 59, 38, 285, DateTimeKind.Local).AddTicks(6348),
                            LoanAgreementId = 1,
                            RemainingTotal = 2324m,
                            RequiresProofOfPayment = false,
                            TransactionType = "Cash"
                        });
                });

            modelBuilder.Entity("Loan_Buddy_Api.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "bill@gmail.com",
                            Name = "Bill",
                            Password = "123"
                        },
                        new
                        {
                            UserId = 2,
                            Email = "Janet@gmail.com",
                            Name = "Janet",
                            Password = "123"
                        });
                });

            modelBuilder.Entity("Loan_Buddy_Api.Models.LoanAgreement", b =>
                {
                    b.HasOne("Loan_Buddy_Api.Models.User", "BorrowerDetail")
                        .WithMany()
                        .HasForeignKey("BorrowerId");

                    b.HasOne("Loan_Buddy_Api.Models.User", "LenderDetail")
                        .WithMany()
                        .HasForeignKey("LenderId");

                    b.Navigation("BorrowerDetail");

                    b.Navigation("LenderDetail");
                });

            modelBuilder.Entity("Loan_Buddy_Api.Models.Transaction", b =>
                {
                    b.HasOne("Loan_Buddy_Api.Models.LoanAgreement", null)
                        .WithMany("Transactions")
                        .HasForeignKey("LoanAgreementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Loan_Buddy_Api.Models.LoanAgreement", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
