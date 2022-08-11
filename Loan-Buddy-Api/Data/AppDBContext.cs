using Microsoft.EntityFrameworkCore;

namespace Loan_Buddy_Api.Data
{
    internal sealed class AppDBContext : DbContext
    {
        public DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) => dbContextOptionsBuilder.UseSqlite("Data Source=./Data/AppDB.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Users[] usersToSeed = new Users[3];

            List<string> names = new() { "Carl", "Karen", "Joe" };

            for (int i = 0; i < names.Count; i++)
            {
                usersToSeed[i] = new Users
                {
                    UserId = i + 155,
                    Name = $"{names[i]}",
                    Email = $"{names[i]}@gmail.com",
                    Password = "password"
                };
            }

            modelBuilder.Entity<Users>().HasData(usersToSeed);
        }
    }


}
                       