using Loan_Buddy_Api;
using Loan_Buddy_Api.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowedOrigins",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000", "http://localhost:3001") // note the port is included 
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors("MyAllowedOrigins");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var ctx = new AppDBContext())
{
    var user = new User() { Name = "Bill", Email ="bill@gmail.com", Password = "password" };
    var loanAgreement = new LoanAgreement()
    { BorrowerId = 1, DateCreated = DateTime.Now, LenderId = 2, 
      MonthlyPaymentAmount = 240, OriginalAmount = 24242, RemainingTotal = 2424 };

    var transaction = new Transaction()
    {
        Amount = 55,
        Date = System.DateTime.Now,
        LoanAgreementId = 1,
        TransactionType = TransactionType.Cash.ToString(),
        ProofOfPayment = false,
        RemainingTotal = 2324
    };
      
    ctx.Users.Add(user);
    ctx.LoanAgreements.Add(loanAgreement);
    ctx.Transactions.Add(transaction);
    ctx.SaveChanges();
}
app.UseHttpsRedirection();
app.MapControllers();


app.Run();
